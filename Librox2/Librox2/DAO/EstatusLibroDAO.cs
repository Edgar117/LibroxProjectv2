using System.Data.SqlClient;
using Librox2.BO;
using System.Data;

namespace Librox2.DAO
{
    public class EstatusLibroDAO
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        SqlCommand cmdauera = new SqlCommand();
        string SQL = "";
        public int SaveCategoria(object obj)
        {
            EstadoLibroBO nom = (EstadoLibroBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "INSERT INTO ESTADOLIBRO (NombreEstatus,status) VALUES( '" + nom.NombreStatus + "','" + nom.Status + "')";
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
        public int UpdateStatusLibro(object obj)
        {
            EstadoLibroBO nom = (EstadoLibroBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE ESTADOLIBRO SET NombreEstatus='" + nom.NombreStatus + "',Status=" + nom.Status + " WHERE ID=" + nom.ID + "";
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
        public int DeleteStatusLibros(object obj)
        {
            CategoriasBO nom = (CategoriasBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "DELETE FROM ESTADOLIBRO WHERE ID=" + nom.ID + "";
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
        public DataTable ConsultarStatusLibro()
        {
            SQL = "SELECT ID AS 'Identificador', NombreEstatus AS 'Estado del Libro', 'Status' =CASE WHEN Status  = 1 THEN 'Activo' WHEN Status=2 THEN 'Proximamente' ELSE 'No Activo' END FROM ESTADOLIBRO";
            return con.TablaGeneral(SQL);
        }

        public DataTable ConsultarStatusLibrosVista()
        {
            SQL = "SELECT ID,NombreEstatus FROM ESTADOLIBRO WHERE Status=1";
            return con.TablaGeneral(SQL);
        }
    }
}