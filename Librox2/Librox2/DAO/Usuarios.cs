using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static Librox2.Propety;

namespace Librox2.DAO
{
    public class Usuarios
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        SqlCommand cmdauera = new SqlCommand();
        public int SaveUserFB(object obj)
        {
            FacebookUser nom = (FacebookUser)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [SPVerifyUser] '" + nom.name+ "','" + nom.email + "','"+nom.birthday+"'";
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
    }
}