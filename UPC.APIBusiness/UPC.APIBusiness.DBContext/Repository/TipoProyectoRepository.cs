using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class TipoProyectoRepository : BaseRepository, ITipoProyectoRepository
    {
        public EntityBaseResponse GetTipoProyecto()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var tipoProyecto = new List<EntityTipoProyecto>();
                    const string sql = "usp_Listar_TipoProyecto";
                    tipoProyecto = db.Query<EntityTipoProyecto>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (tipoProyecto.Count > 0)
                    {

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = tipoProyecto;
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
