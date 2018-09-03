using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Librox2.DAO
{
    public class Conexion
    {  //Variables de Conexion
        SqlConnection con;
        
        public SqlConnection EstablecerConexion()
        {
            //Obtiene la cadena de conexión del webconfig
            string cs = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }
        public void AbrirConexion()
        {
            con.Open();
        }
        public void CerrarConexion()
        {
            con.Close();
        }
        //Merodo General Sentencias
        public int EjecutarSentencia(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = EstablecerConexion();
            AbrirConexion();
            cmd.CommandText = sql;
            int valor = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (valor <= 0)
            {
                return 0;
            }
            return 1;

        }
        //Metodo General para Tablas
        public DataTable TablaGeneral(string sql)
        {
            SqlDataAdapter TablaX = new SqlDataAdapter(sql, EstablecerConexion());
            DataTable TablaConsulta = new DataTable();
            TablaX.Fill(TablaConsulta);
            return TablaConsulta;
        }
    }
}