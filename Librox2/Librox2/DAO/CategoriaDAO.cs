using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Librox2.BO;
using System.Data;

namespace Librox2.DAO
{
    public class CategoriaDAO
    {
        SqlCommand cmd = new SqlCommand();
        Conexion con = new Conexion();
        SqlCommand cmdauera = new SqlCommand();
        string SQL = "";
        public int SaveCategoria(object obj)
        {
            CategoriasBO nom = (CategoriasBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "INSERT INTO Categorias (NombreCategoria,status) VALUES( '" + nom.NombreCategoria + "','"+nom.Status+"')";
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
        public int UpdateCategoria(object obj)
        {
            CategoriasBO nom = (CategoriasBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "UPDATE Categorias SET NombreCategoria='"+nom.NombreCategoria+"',Status="+nom.Status+" WHERE ID="+nom.ID+"";
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
        public int DeleteCategorias(object obj)
        {
            CategoriasBO nom = (CategoriasBO)obj;
            cmd.Connection = con.EstablecerConexion();
            string sql = "DELETE FROM Categorias WHERE ID="+nom.ID+"";
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
            SQL = "SELECT ID AS 'Identificador', NombreCategoria AS 'Categoria', 'Status' =CASE WHEN Status  = 1 THEN 'Activo' WHEN Status=2 THEN 'Proximamente' ELSE 'No Activo' END FROM Categorias";
           return con.TablaGeneral(SQL);
        }

        public DataTable ConsultarCategoriasLibrosVista()
        {
            SQL = "SELECT NombreCategoria FROM Categorias WHERE Status=1";
            return con.TablaGeneral(SQL);
        }
    }
}