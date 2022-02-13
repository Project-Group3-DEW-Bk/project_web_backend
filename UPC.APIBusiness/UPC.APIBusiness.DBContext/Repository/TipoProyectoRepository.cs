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

        public EntityBaseResponse InsertarTipoProyecto(EntityTipoProyecto tipoproyecto)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarTipoProyecto";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODTIPO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@TIPOPROYECTO", value: tipoproyecto.tipoproyecto, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityTipoProyecto>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idtipoproyecto = p.Get<int>("@CODTIPO");

                    if (idtipoproyecto > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idtipoproyecto,
                            nombre = tipoproyecto.tipoproyecto
                        };
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
