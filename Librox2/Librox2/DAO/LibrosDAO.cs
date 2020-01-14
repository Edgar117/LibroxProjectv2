using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Librox2.BO;
using System.Data;

namespace Librox2.DAO
{
    public class LibrosDAO
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        SqlCommand cmdauera = new SqlCommand();
        string SQL = "";
        //Metodó que guarda el libro que el usuario este registrando.
        public int SaveBook(object obj)
        {
            LibrosBO nom = (LibrosBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [spInsertBook] NULL,'" + nom.Titulo + "','" + nom.Sinpsis + "'," + nom.Autor_ID + ",'" + nom.ImagenPòrtada + "',null,null,'" + nom.LibroFisico + "','" + nom.Categoria + "','" + nom.EstatusLibro + "'";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            } 
            return 1;
        }


        //Metoto para actualizar el estatus del los pagos de la tabla de pagos
        public int ActualizarPagoUsuario(int IDPago)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE [dbo].[ProcesoPagoPaypal] SET EstatusPago='COMPLETED' WHERE IDPago="+ IDPago;
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        //Metoto para actualizar cuanto se le pagara al usuario
        public int InsertarPagoUsuario(int ID_Vendedor,Decimal PrecioReal,Decimal PrecioFinal,string Correo)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [dbo].[InsertarPagoToPay] "+ID_Vendedor+","+PrecioReal+","+PrecioFinal+" ,'"+Correo+"'";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }


        //Metoto para ranquear libros deacuerdo al usuario que tiene comprado el libro y si ya lo ranqueo o no
        public int UpdRantingLibros(int IDPago,int IDUsuario,int IDLibro, int Valoracion)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [dbo].[St_SelUpdValoradoSetRating] " + IDPago + "," + IDUsuario + "," + IDLibro + "," + Valoracion + " ";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        //Metodo para recuperar los libros que el usuario ah adquirido
        public DataTable ConsultarMisLibrosComprados(int ID_Usuario)
        {
            SQL = "EXEC [DBO].[ST_SelMisLibrosComprados] " + ID_Usuario+"";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }

        public DataTable ConsultarLibrosComprados()
        {
            SQL = @"SET LANGUAGE SPANISH
SELECT LS.Titulo as Libro,US.Usuario,PP.PrecioAPagar as 'Precio de venta',FORMAT(PP.FechaPeticion , 'dd/MMMM/yyyy HH:mm') AS 'Dia de Venta' FROM LIBROS LS
INNER JOIN [dbo].[ProcesoPagoPaypal] PP ON PP.IDLibroAComprar=LS.IDLibro
INNER JOIN USUARIOS US ON US.ID=PP.IDUsuarioPeticion
WHERE  PP.EstatusPayPal='COMPLETED'";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }

        //Metodo para insertar las peticiones de los usuarios de los libros
        public string ProcesarLibroPaypal(object obj, int IdUsuario)
        {
            LibrosBO nom = (LibrosBO)obj;
            string sql = "EXEC [dbo].[ProcesarPago] "+IdUsuario+", "+nom.Precio+",'" + nom.Titulo + "'";
            DataTable DevuelveId = PruebaID(sql);
            DataRow row = DevuelveId.Rows[0];
            return row["ID"].ToString();
        }
        //Método copiado
        public DataTable PruebaID( string sql)
        {
            SQL = "SELECT SCOPE_IDENTITY() as id";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(sql);
        }

        //Metodò general que consulta todos los libros que se tienen en el portal.
        public DataTable ConsultarLibros()
        {
            SQL = "EXEC [DBO].[PaginadorLibros]";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarLibrosApp()
        {
            SQL = "EXEC [dbo].[PaginadorLibrosApp]";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarLibrosByNameApp(string NameBook)
        {
            SQL = "EXEC [dbo].[SelPaginadorLibrosXTituloApp] '"+NameBook+"'";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarComentariosByNameApp(string NameBook)
        {
            SQL = "EXEC [dbo].[SelComentByBook] '" + NameBook + "'";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        //Metodò general que consulta datos de un libro.
        public DataTable ConsultarLibrosXNombreLibro(string NombreLibro)
        {
            SQL = "EXEC [dbo].[SelPaginadorLibrosXNombreLibro] '" + NombreLibro + "'";
            return con.TablaGeneral(SQL);
        }

        //Metodo que devuelve los comentarios deacuerdo al libro que se este buscando.
        public DataTable ConsultaComentariosLibros(string IDLibro)
        {
            SQL = "SET LANGUAGE SPANISH SELECT IDComentario AS ID, Comentarios.Usuario,Comentario, FORMAT(Hora , 'yyyy-MM-dd HH:mm:ss') AS Hora ,Libro AS Libro,US.ImagenUsuario FROM Comentarios INNER JOIN Usuarios US ON US.Usuario= Comentarios.Usuario WHERE Libro='" + IDLibro + "' ORDER BY Hora DESC";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        //Metodo para consultar los comentarios de lado del administrador de la pagina
        public DataTable ConsultaComentariosLibrosAdmin()
        {
            SQL = "SET LANGUAGE SPANISH SELECT IDComentario AS ID, Usuario,Comentario, FORMAT(Hora , 'dd/MMMM/yyyy HH:mm') AS Hora ,Libro AS Libro FROM Comentarios";
            //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }

        //Este metodó pagina libros segun la categoria que el usuario escoja.
        public DataTable ConsultarLibrosPorCategorias(string CategoriaToFind)
        {
            SQL = "EXEC [dbo].[PaginadorCategorias] '" + CategoriaToFind + "'";
            return con.TablaGeneral(SQL);
        }
        //Este metodó pagina libros segun el texto que mande el usuario, si el usuario manda Angular el sp buscara todas las coincidencias con esa palabra en el titulo.
        public DataTable ConsultarLibrosXTexto(string Texto)
        {
            SQL = "EXEC [dbo].[SelPaginadorLibrosXTitulo] '" + Texto + "'";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarLibroDescargaApp(string ID)
        {
            SQL = "EXEC [dbo].[SelGetNameBookDescarga] '" + ID + "'";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarBiblotecaUsuario(string ID)
        {
            SQL = "EXEC [dbo].[ST_SelMisLibrosCompradosByApp] '" + ID + "'";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarLibrosXIDApp(string ID)
        {
            SQL = "EXEC [dbo].[SelPaginadorLibrosXIDApp] '" + ID + "'";
            return con.TablaGeneral(SQL);
        }

        //Consulta libros para el admin
        public DataTable ConsultarLibrosAdmin()
        {
            SQL = "SELECT ls.IDLibro AS Identificador, ls.Titulo,LS.Categoria,US.Usuario  FROM LIBROS LS INNER JOIN USUARIOS US ON LS.ID_Autor = US.ID WHERE LS.RegBorrado = 0";
            return con.TablaGeneral(SQL);
        }

        public DataTable ConsultarMiPago(int IDUsuario)
        {
            SQL = " EXEC [dbo].[st_SelCalculaMiPago] " + IDUsuario + "";
            return con.TablaGeneral(SQL);
        }

        public DataTable ConsultarPagosPendientes()
        {
            SQL = " EXEC  [dbo].[st_SelPagosPendientes]";
            return con.TablaGeneral(SQL);
        }
        //Actuliza el estatus de la venta segun si fue verificado o no
        public int UpdEstatusVentaPaypal(string IDVenta, string orderID)
        {
            cmd.Connection = con.EstablecerConexion();
            

            string sql = "EXEC [dbo].[UpdEstatusPago] '" + IDVenta + "' ,'" + orderID + "'";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        //Metodo para actualizar el campo descargado de la base de datos
        public int UpdCampoDescargado(string IDVenta, string orderID)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE  [dbo].[ProcesoPagoPaypal] SET Descargado=1 WHERE IDPago=" + IDVenta + " ";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }

        public int UpdateUser(object obj)
        {
            UsuarioBO nom = (UsuarioBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE USUARIOS SET DescriptionUser ='" + nom.DescriptionUser + "', Categoria='" + nom.Categoria + "',ImagenUsuario='" + nom.Imagen + "' WHERE ID=" + nom.ID + " ";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        //Metodó que actualiza el libro del usuario, ya sea con imagen o sin ella.
        public int UpdLibro(object obj)
        {
            LibrosBO nom = (LibrosBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [spUpdateDelete] '" + nom.ID_LIBRO + "','" + nom.Titulo + "','" + nom.Sinpsis + "','" + nom.ImagenPòrtada + "','" + nom.Categoria + "','" + nom.EstatusLibro + "','" + nom.Action + "','" + nom.LibroFisico + "'  ";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        //Metodo que Inserta los comentarios de los libros para despues poder verlos en la pagina.
        public int InsertarComentarios(object obj)
        {
            ComentariosBO nom = (ComentariosBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "INSERT INTO Comentarios (Usuario,Comentario,Libro) VALUES ('" + nom.Usuario + "',N'" + nom.Comentarios + "','" + nom.Libro + "')";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int InsertarComentariosApp(string Usuario,string IDLibro,string Comentario)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "[dbo].[InsertComentariosApp] '" + Usuario + "','" + IDLibro + "',N'" + Comentario + "'";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        //Elimina los comentarios desde el admin
        public int EliminarComentariosAdmin(object obj)
        {
            ComentariosBO nom = (ComentariosBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "DELETE FROM Comentarios WHERE IDComentario=" + nom.IDComentario + "";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }


        //Elimina un libro fisicamente de manera logica
        public int EliminarComentariosAdmin(int ID)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC ST_Del_Libro " + ID + "";
            cmd.CommandText = sql;
            con.AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            con.CerrarConexion();
            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }
        public int CONTARLIBROS()
        {
            int CUENTA = 0;
            SQL = "Select COUNT(*) FROM LIBROS WHERE ISNULL(RegBorrado,0)=0";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", CUENTA);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                CUENTA = int.Parse(leer[0].ToString());
            }
            con.CerrarConexion();
            return CUENTA;
        }

        //Metodó que cuenta los usuarios con los que cuenta la pagina.
        public int ContarUsuarios()
        {
            int CUENTA = 0;
            SQL = "SELECT COUNT(*) FROM Usuarios WHERE TipoUsuario=0";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", CUENTA);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                CUENTA = int.Parse(leer[0].ToString());
            }
            con.CerrarConexion();
            return CUENTA;

        }


        //Metodó que cuenta los usuarios con los que cuenta la pagina.
        public int ContarVentas()
        {
            int CUENTA = 0;
            SQL = "SELECT COUNT(*) FROM [dbo].[ProcesoPagoPaypal] PP WHERE PP.EstatusPayPal='COMPLETED' AND PP.Descargado=0";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", CUENTA);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                CUENTA = int.Parse(leer[0].ToString());
            }
            con.CerrarConexion();
            return CUENTA;

        }
    }
}
