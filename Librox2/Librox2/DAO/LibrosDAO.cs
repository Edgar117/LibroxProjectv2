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
            LibrosBO  nom = (LibrosBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [spInsertBook] NULL,'"+nom.Titulo+"','"+nom.Sinpsis+"',"+nom.Autor_ID+",'"+nom.ImagenPòrtada+"',null,null,'"+nom.LibroFisico+"','"+nom.Categoria+"','"+nom.EstatusLibro+"'";
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
        //Metodò general que consulta todos los libros que se tienen en el portal.
        public DataTable ConsultarLibros()
        {
            SQL="EXEC [DBO].[PaginadorLibros]";
           //SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        //Este metodó pagina libros segun la categoria que el usuario escoja.
        public DataTable ConsultarLibrosPorCategorias(string CategoriaToFind)
        {
            SQL = "EXEC [dbo].[PaginadorCategorias] '"+CategoriaToFind+"'";
            return con.TablaGeneral(SQL);
        }
        //Este metodó pagina libros segun el texto que mande el usuario, si el usuario manda Angular el sp buscara todas las coincidencias con esa palabra en el titulo.
        public DataTable ConsultarLibrosXTexto(string Texto)
        {
            SQL = "EXEC [dbo].[SelPaginadorLibrosXTitulo] '" + Texto + "'";
            return con.TablaGeneral(SQL);
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
            string sql = "EXEC [spUpdateDelete] '"+nom.ID_LIBRO+ "','" + nom.Titulo + "','" + nom.Sinpsis + "','" + nom.ImagenPòrtada + "','" + nom.Categoria + "','" + nom.EstatusLibro + "','" + nom.Action + "'  ";
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
        //public string validarusuario(UsuarioBO ObjUsuario)
        //{

        //    string contra = "";

        //    SQL = "Select Contraseña,Tipousuario,ImagenUsuario,DescriptionUser,Categoria,ID from Usuarios  where Usuario = '" + ObjUsuario.Usuario + "'";
        //    SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
        //    con.AbrirConexion();
        //    cmd.Parameters.AddWithValue("@Usuario", contra);
        //    SqlDataReader leer = cmd.ExecuteReader();
        //    if (leer.Read())
        //    {
        //        contra = leer["Contraseña"].ToString() + "|" + leer["Tipousuario"].ToString() + "|" + leer["ImagenUsuario"].ToString() + "|" + leer["DescriptionUser"].ToString() + "|" + leer["Categoria"].ToString() + "|" + leer["ID"].ToString();
        //    }
        //    con.CerrarConexion();
        //    return contra;

        //}
        
         //Metodó que cuenta los libros, con los que cuenta la página
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
                CUENTA =int.Parse( leer[0].ToString());
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
