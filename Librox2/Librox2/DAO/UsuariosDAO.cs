﻿using System;
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
            string sql = "EXEC [SPVerifyUser] '" + nom.name+ "','" + nom.email + "','"+nom.birthday+"','"+nom.name+"','"+nom.picture+"'";
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


        //Metodo para insertar seguidores a un usuario.
        public int InsertaSeguidores(int UsuarioLogeado ,int UsuarioASeguir)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "EXEC [dbo].[SelRegistrarSeguidores] " + UsuarioLogeado + ","+UsuarioASeguir+"";
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

        public int DeleteUser(object obj)
        {
            UsuarioBO nom = (UsuarioBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "DELETE USUARIOS WHERE ID ='" + nom.ID + "'";
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
            SQL = "SELECT ID,Nombre,Usuario,Correo FROM USUARIOS WHERE TipoUsuario=0";
            return con.TablaGeneral(SQL);
        }
        //Metodo que devuelve información basica del usuario
        public DataTable ConsultaDatosUsuario(string Usuario)
        {
            SQL = "SELECT ID AS 'Identificador',Usuario,Correo,ImagenUsuario as 'Imagen',Seguidores FROM Usuarios WHERE TipoUsuario=0 AND Usuario='"+Usuario+"'";
            return con.TablaGeneral(SQL);
        }

        public DataTable ConsultaDatosLibrosXUsuario(string Usuario)
        {
            SQL = "SELECT COUNT(LS.IDlibro)AS Libros FROM Usuarios INNER JOIN LIBROS LS ON LS.ID_Autor = Usuarios.ID WHERE TipoUsuario = 0 AND  Usuario='" + Usuario + "'";
            return con.TablaGeneral(SQL);
        }

        public DataTable ConsultarUsuariosAdmin()
        {
            SQL = "SELECT ID,Nombre,Usuario,Correo FROM USUARIOS WHERE TipoUsuario=1";
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

        public int UpdateCuentaDepositoPaypal(string Correo,int ID)
        {
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE USUARIOS SET TargetaPaypal ='" +Correo + "' WHERE ID=" + ID+ " ";
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
            
            SQL = "Select TOP 1 Contraseña,Tipousuario,ImagenUsuario,DescriptionUser,Categoria,ID,(SELECT COUNT(*) FROM [dbo].[fnSplit](US.Seguidores,',')) AS 'SEGUIDORES',(select count(*) from LIBROS where ID_Autor=US.ID)  as 'TotalLibros' from Usuarios US  where Usuario = '"+ObjUsuario.Usuario+ "'OR Correo='"+ObjUsuario.Usuario+"'";
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
        public string GetUserName(string IDUser)
        {

            string User = "";

            SQL = "SELECT Usuario FROM Usuarios WHERE ID='"+IDUser+"'";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", User);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                User =leer["Usuario"].ToString();
            }
            con.CerrarConexion();
            return User;

        }
        public string GetUserIDByName(string UserName)
        {

            string User = "";

            SQL = "SELECT ID FROM Usuarios WHERE Usuario='" + UserName + "'";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                User = leer["ID"].ToString();
            }
            con.CerrarConexion();
            return User;

        }
        public string ValidarCorreoToReset(string Correp)
        {

            string contra = "";

            SQL = "exec RecoveryPass '" + Correp + "'";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", contra);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                contra = leer["MENSAJE"].ToString();
            }
            con.CerrarConexion();
            return contra;

        }
        public string ObtenerTargetaPaypal(int ID)
        {

            string contra = "";

            SQL = "SELECT TargetaPaypal FROM Usuarios WHERE ID= " + ID + "";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            //cmd.Parameters.AddWithValue("@Usuario", contra);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                contra = leer["TargetaPaypal"].ToString();
            }
            con.CerrarConexion();
            return contra;

        }
        public string validarusuarioApp(string Usuario,string Pass)
        {
            Security S = new Security();
            string passEncry = S.encrypt(Pass);
            string ID = "";
            SQL = " EXEC [dbo].[ValidUserApp] '"+Usuario+"','"+passEncry+"'";
            SqlCommand cmd = new SqlCommand(SQL, con.EstablecerConexion());
            con.AbrirConexion();
            cmd.Parameters.AddWithValue("@Usuario", Usuario);
            SqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                ID = leer[0].ToString();
            }
            con.CerrarConexion();
            return ID;

        }
        public DataTable GetInformationUserApp(string ID)
        {
            SQL = "EXEC [dbo].[St_GetInformationApp] " + ID;
            return con.TablaGeneral(SQL);
        }
        public DataTable GetMysales(string ID)
        {
            SQL = "EXEC  [dbo].[st_SelCalculaMiPagoApp] " + ID;
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarMisLibros(int ID)
        {
            SQL = "SELECT ImagenPortada FROM LIBROS WHERE ID_Autor='"+ID+"' AND RegBorrado=0";
            return con.TablaGeneral(SQL);
        }
        public DataTable ConsultarMisLibrosToEdit(int ID)
        {
            SQL = "SELECT IDLibro,Titulo,Sinopsis,Categoria,ImagenPortada FROM LIBROS WHERE RegBorrado=0 AND ID_Autor='" + ID + "'";
            return con.TablaGeneral(SQL);
        }
    }
}
