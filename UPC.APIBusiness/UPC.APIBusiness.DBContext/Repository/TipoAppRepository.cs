using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Dapper;

namespace DBContext
{
    public class TipoAppRepository : BaseRepository, ITipoAppRepository
    {
        public EntityBaseResponse GetTipoApp()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var tipoApp = new List<EntityTipoApp>();
                    const string sql = "usp_Listar_TipoApp";
                    tipoApp = db.Query<EntityTipoApp>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (tipoApp.Count > 0)
                    {

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = tipoApp;
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
