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
        public DataTable ConsultarLibros()
        {
            SQL = "SELECT Titulo, Sinopsis, US.Usuario AS 'Autor',RG.PRECIO,ImagenPortada,Ranking ,Libros.Categoria,EL.[NombreEstatus] FROM LIBROS  INNER JOIN RANKING RG ON RG.ID = LIBROS.ID_PRECIO   INNER JOIN Usuarios US ON US.ID = LIBROS.ID_AUTOR   INNER JOIN EstadoLibro EL ON EL.ID = LIBROS.[ID_EstatusLibro]";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarLibrosPorCategorias(string CategoriaToFind)
        {
            SQL = "EXEC [dbo].[PaginadorCategorias] '"+CategoriaToFind+"'";
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
        public int UpdateBookWithOutImage(object obj)
        {
            LibrosBO nom = (LibrosBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE LIBROS SET Titulo='" + nom.Titulo + "',Sinopsis='" + nom.Sinpsis + "',Categoria='"+nom.Categoria+"' WHERE IDLibro='" + nom.ID_LIBRO + "' ";
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
    }
}