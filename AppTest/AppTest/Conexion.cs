using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AppTest
{
    class Conexion
    {
        static SqlConnection cnx;
        static string cadena = @"Server=localhost\SQLEXPRESS;Database=EjecutarAcciones;Trusted_Connection=True;";

        private static void conectar()
        {
            cnx = new SqlConnection(cadena);
            cnx.Open();
        }
        private static void Desconectar()
        {
            cnx.Close();
            cnx=null; 
        }
        public static int EjecutaConsulta(String consulta)
        {
            int filasAfectadas = 0;
            conectar();
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }
        public static DataTable EjecutaSeleccion(string consulta)
        {
            DataTable dt = new DataTable();
            conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt;
        }
        public static Object EjecutaEscalar(string consulta)
        {
            DataTable dt = new DataTable();
            conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt.Rows[0].ItemArray[0];
        }
    }
}
