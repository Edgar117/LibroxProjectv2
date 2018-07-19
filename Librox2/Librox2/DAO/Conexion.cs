using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Librox2.DAO
{
    public class Conexion
    {  //Variables de Conexion
        SqlConnection con;

        public SqlConnection EstablecerConexion()
        {
            string cs = "Data Source =NGC32; Initial Catalog = Librox; User Id =sa; Password=ngcgab;";
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
        //Metodo Generar para Tablas
        public DataTable TablaGeneral(string sql)
        {
            SqlDataAdapter TablaX = new SqlDataAdapter(sql, EstablecerConexion());
            DataTable TablaConsulta = new DataTable();
            TablaX.Fill(TablaConsulta);
            return TablaConsulta;
        }
    }
}