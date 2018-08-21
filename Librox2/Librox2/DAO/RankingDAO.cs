using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Librox2.BO;
namespace Librox2.DAO
{
    public class RankingDAO
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        SqlCommand cmdauera = new SqlCommand();
        string SQL = "";
        public int SaveRanking(object obj)
        {
            Ranking nom = (Ranking)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "INSERT INTO Ranking (Rango,Precio) VALUES( '" + nom.RankingNom + "'," + nom.Precio + ")";
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
        public int UpdatePrecio(object obj)
        {
            Ranking nom = (Ranking)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE Ranking SET Precio=" + nom.Precio + " WHERE ID=" + nom.ID + "";
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
        public int DeletePrecio(object obj)
        {
            Ranking nom = (Ranking)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "DELETE FROM Ranking WHERE ID=" + nom.ID + "";
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
        public DataTable ConsultarRankgin()
        {
            SQL = "SELECT ID AS 'Identificador',Rango AS 'Estrellas',Precio AS 'Precio' FROM Ranking";
            return con.TablaGeneral(SQL);
        }
    }
}