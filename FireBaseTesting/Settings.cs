using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class Settings
    {
        public int Iniciada = 1;
        public int Envasando = 2;
        public int Detenida = 3;
        public int Lavando = 4;
        public int Terminada = 5;        
        public int SinParada = 0;
        public int Reiniciando = 6;

        /// <summary>
        /// TimeToDateTime
        /// </summary>
        /// <param name="unixtime"></param>
        /// <returns></returns>

        public SqlConnection cnxSQL = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        /// <summary>
        /// Metodo para conectar a base de datos SQL
        /// </summary>
        public void Connect()
        {
            if (cnxSQL.State == ConnectionState.Closed)
            {
                cnxSQL.Open();
            }
        }
        /// <summary>
        /// Metodo para desconectar base de datos SQL
        /// </summary>
        public void Disconnect()
        {
            if (cnxSQL.State == ConnectionState.Open)
            {
                cnxSQL.Close();
            }
        }
    }
}