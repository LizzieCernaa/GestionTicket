using System;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace DynaIT.Clases
{
    public class Conexion_MySQL
    {
        //defino las propiedades o atributos de la clase conexion
        //private static MySqlConnection objetoConexion;

        private static SqlConnection objetoConexion;
        private static string error;

        //definir mis metodos para hacer la conexion 
        public static SqlConnection getConexion()
        {
            if (objetoConexion != null)
                return objetoConexion;
            objetoConexion = new SqlConnection(@"Server=127.0.0.1,1433;Database=DynaIT;User Id=Lizzie;Password=NADA1234;");

            try
            {
                objetoConexion.Open();
                return objetoConexion;

            }
            catch (Exception e)
            {

                error = e.Message;
                return null;
            }
        }
    }
}