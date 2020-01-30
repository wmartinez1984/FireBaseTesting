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
        public static int L1 = 1;
        public static int L2 = 2;
        public static int L3 = 3;
        public int Iniciada = 1;
        public int Envasando = 2;
        public int Detenida = 3;
        public int Lavando = 4;
        public int Terminada = 5;        
        public int SinParada = 0;
        public int Reiniciando = 6;
        public bool ExistSession = true;


        public static  Guid id;
        public static string OP;
        public static string ProductoOP;
        public static string Descripcion;
        public static string Cantidad;
        public static string Ubicacion;
        public static string CodCliente;
        public static string NombreCliente;
        public static int EestadoL1;
        public static int EestadoL2;
        public static int EestadoL3;
        public static int EestadoOP;
        public static int MinParadaL1;
        public static int MinParadaL2;
        public static int MinParadaL3;
        public static int TiempoLavado;
        public static string DescripLavado;
        public static string HoraInicio;
        public static string HoraFinalizacion;
        public static string CantFabricados;
        public static DateTime FechaCreacion;
        public static DateTime FechaModificacion;
        public static DateTime FechaParadaL1;
        public static DateTime FechaParadaL2;
        public static DateTime FechaParadaL3;
        public static DateTime FechaInicioLavado;

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