using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librox2.BO;
using System.Data.SqlClient;
using System.Data;

namespace Librox2.DAO
{
    public class MensajesDAO
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        string SQL = "";
        public int SaveMensaje(object obj)
        {
            Mensajes nom = (Mensajes)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "INSERT INTO Mensajes (Nombre,Correo,Mensaje) VALUES( '" + nom.Nombre + "','" + nom.Correo + "','"+nom.Mensaje+"')";
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
        public int UpdateMensaje(object obj)
        {
            CategoriasBO nom = (CategoriasBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE Categorias SET NombreCategoria='" + nom.NombreCategoria + "',Status=" + nom.Status + " WHERE ID=" + nom.ID + "";
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
        public int DeleteMensaje(object obj)
        {
            Mensajes nom = (Mensajes)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "DELETE FROM Mensajes WHERE ID=" + nom.IDMensaje + "";
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
        public DataTable ConsultarCategorias()
        {
            SQL = "SELECT ID AS 'Identificador', Nombre AS 'Nombre Persona', Correo, Mensaje FROM Mensajes";
            return con.TablaGeneral(SQL);
        }
    }
}