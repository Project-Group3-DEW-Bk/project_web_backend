using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class EstadoProyectoRepository : BaseRepository, IEstadoProyectoRepository
    {
        public EntityBaseResponse GetEstadoProyecto()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var estadoProyectos = new List<EntityEstadoProyecto>();
                    const string sql = "usp_Listar_EstadoProyecto";
                    estadoProyectos = db.Query<EntityEstadoProyecto>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (estadoProyectos.Count > 0)
                    {

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = estadoProyectos;
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

        public EntityBaseResponse InsertarEstadoProyecto(EntityEstadoProyecto estadoproyecto)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarEstadoProyecto";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODESTADO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@ESTADOPROYECTO", value: estadoproyecto.estadoproyecto, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityEstadoProyecto>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idestadoproyecto = p.Get<int>("@CODESTADO");

                    if (idestadoproyecto > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idestadoproyecto,
                            nombre = estadoproyecto.estadoproyecto
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
