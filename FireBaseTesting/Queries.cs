using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class Queries
    {

        /// <summary>
        /// Metodo general de consultas (Consultas genéricas)
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public SqlDataReader Select(string Query, SqlParameter[] parametros = null)
        {
            Settings cfn = new Settings();
            cfn.Connect();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cfn.cnxSQL;
            comando.CommandText = Query;
            if (parametros != null)
            {
                comando.CommandType = CommandType.Text;
                foreach (SqlParameter p in parametros)
                {
                    if (p.Value != null && p.Value.ToString() != "00000000-0000-0000-0000-000000000000")
                        comando.Parameters.Add(p);
                }
            }
            else
            {
                comando.CommandType = CommandType.Text;
            }
            SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }

        public void Insert(string Query, SqlParameter[] parametros = null)
        {
            Settings cfn = new Settings();
            cfn.Connect();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cfn.cnxSQL;
            comando.CommandText = Query;
            if (parametros != null)
            {
                comando.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in parametros)
                {
                    comando.Parameters.Add(p);
                }
            }
            else
            {
                comando.CommandType = CommandType.StoredProcedure;
            }

            comando.ExecuteNonQuery();
            cfn.Disconnect();
        }

    }
}