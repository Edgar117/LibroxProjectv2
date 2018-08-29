using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static Librox2.Propety;
using Librox2.BO;
using System.Data;

namespace Librox2.DAO
{
    public class UsuariosDAO
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        SqlCommand cmdauera = new SqlCommand();
        string SQL="";
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
        public int SaveUserRegister(object obj)
        {
            UsuarioBO nom = (UsuarioBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "INSERT INTO USUARIOS (Nombre,Usuario,Correo,Cumpleaños,Contraseña,TipoUsuario,DescriptionUser) VALUES( '" + nom.Nombre+ "','" + nom.Usuario + "','" + nom.Correo + "','" + nom.Cumpleaños + "','"+nom.Contraseña+"','" + nom.TipoUsuario + "','" + nom.DescriptionUser + "')";
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
        public DataTable ConsultarUsuarios()
        {
            SQL = "SELECT ID,Nombre,Usuario,Correo FROM USUARIOS";
            return con.TablaGeneral(SQL);
        }
        public int UpdateUser(object obj)
        {
            UsuarioBO nom = (UsuarioBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE USUARIOS SET DescriptionUser ='"+nom.DescriptionUser+ "', Categoria='"+nom.Categoria+"',ImagenUsuario='"+nom.Imagen+"' WHERE ID="+nom.ID+" ";
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
        public string validarusuario(UsuarioBO ObjUsuario)
        {

            string contra = "";
            
            SQL = "Select TOP 1 Contraseña,Tipousuario,ImagenUsuario,DescriptionUser,Categoria,ID,(select count(*) from seguidores where ID_Usuario=3) AS 'SEGUIDORES',(select count(*) from LIBROS where ID_Usuario=3)  as 'TotalLibros' from Usuarios US LEFT JOIN Seguidores SR ON SR.ID_Usuario = US.ID where Usuario = '"+ObjUsuario.Usuario+"'";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", contra);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                contra = leer["Contraseña"].ToString()+"|"+leer["Tipousuario"].ToString()+"|" + leer["ImagenUsuario"].ToString()+"|" + leer["DescriptionUser"].ToString() + "|" + leer["Categoria"].ToString()+ "|" + leer["ID"].ToString()+"|"+ leer["SEGUIDORES"].ToString()+"|"+ leer["TotalLibros"].ToString();
            }
            con.CerrarConexion();
            return contra;

        }
    }
}
