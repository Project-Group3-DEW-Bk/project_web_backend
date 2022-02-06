using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class AplicativoRepository : BaseRepository, IAplicativoRepository
    {
        public EntityBaseResponse GetAplicativo(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var aplicativos = new List<EntityAplicativo>();
                    var sql = "usp_Listar_Aplicativo_X_Proyecto";

                    var p = new DynamicParameters();
                    
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    aplicativos = db.Query<EntityAplicativo>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (aplicativos.Count > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = aplicativos;
                    }
                    else
                    {
                        response.issuccess = false;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = null;
                    }

                }
            }
            catch (Exception ex)
            {
                response.issuccess = false;
                response.errorcode = "0001";
                response.errormensage = ex.Message;
                response.data = null;
            }

            return response;
        }
    }
}
