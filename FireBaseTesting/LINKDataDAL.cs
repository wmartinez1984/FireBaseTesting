using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FireBaseTesting
{
    public class LINKDataDAL
    {
        public void LINKDataInsert(LINKDataEntity lINKDataEntity)
        {
            Queries insert = new Queries();
            var parametros = new SqlParameter[] {
                new SqlParameter("@id", lINKDataEntity.id),
                new SqlParameter("@FechaCaducidad", lINKDataEntity.FechaCaducidad),
                new SqlParameter("@Documento", lINKDataEntity.Documento),
                new SqlParameter("@Descripcion", lINKDataEntity.Descripcion),

            };

            insert.Insert("LinksData_Insert", parametros);
            
        }

        public List<LINKDataEntity> LINKDataSelect(LINKDataEntity lINKDataEntity)
        {

            var data = new List<LINKDataEntity>();
            Queries select = new Queries();
            var parametros = new SqlParameter[] {
                      new SqlParameter("@id", lINKDataEntity.id),

            };

            SqlDataReader reader = select.Select("SELECT [Id],[FechaCaducidad],[Documento],[Descripcion],[FechaCreacion]  FROM [dbo].[LinksData] where  id = @id", parametros);
            while (reader.Read())
            {
                LINKDataEntity LINKDataEntityEntity_ = new LINKDataEntity();
                LINKDataEntityEntity_.id = new Guid(reader["id"].ToString().ToUpper());
                LINKDataEntityEntity_.FechaCaducidad = DateTime.Parse(reader["FechaCaducidad"].ToString());
                LINKDataEntityEntity_.Documento = reader["Documento"].ToString().ToUpper();
                LINKDataEntityEntity_.Descripcion = reader["Descripcion"].ToString().ToUpper();
                LINKDataEntityEntity_.FechaCreacion = DateTime.Parse(reader["FechaCreacion"].ToString());

                data.Add(LINKDataEntityEntity_);
            }
            return data;
        }
    }
}