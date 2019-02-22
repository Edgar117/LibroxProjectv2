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
        //Metodo que devuelve los comentarios deacuerdo al libro que se este buscando.
        public DataTable ConsultaComentariosLibros(string IDLibro)
        {
            SQL = "SELECT IDComentario AS ID, Usuario,Comentario, FORMAT(Hora , 'dd/MMMM/yyyy HH:mm') AS Hora ,Libro AS Libro FROM Comentarios WHERE Libro='" + IDLibro + "' ORDER BY Hora DESC";
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
        //Actuliza el estatus de la venta segun si fue verificado o no
        public int UpdEstatusVentaPaypal(string IDVenta, string orderID)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE  [dbo].[ProcesoPagoPaypal] SET EstatusPayPal='COMPLETED', IndentificadorPaypal = '" + orderID + "'" + " WHERE IDPago=" + IDVenta + " ";
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
            string sql = "EXEC [spUpdateDelete] '" + nom.ID_LIBRO + "','" + nom.Titulo + "','" + nom.Sinpsis + "','" + nom.ImagenPòrtada + "','" + nom.Categoria + "','" + nom.EstatusLibro + "','" + nom.Action + "'  ";
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
            string sql = "INSERT INTO Comentarios (Usuario,Comentario,Libro) VALUES ('" + nom.Usuario + "','" + nom.Comentarios + "','" + nom.Libro + "')";
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
        public int CONTARLIBROS()
        {
            int CUENTA = 0;
            SQL = "Select COUNT(*) FROM LIBROS";
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
    }
}
