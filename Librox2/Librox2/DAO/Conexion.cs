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
            string cs = "Data Source=SQL5013.site4now.net;Initial Catalog=DB_A3EBA7_Librox;User Id=DB_A3EBA7_Librox_admin;Password=Edgar117;";
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