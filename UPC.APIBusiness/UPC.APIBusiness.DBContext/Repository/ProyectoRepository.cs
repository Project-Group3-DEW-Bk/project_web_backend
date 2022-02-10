using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class ProyectoRepository : BaseRepository, IProyectoRepository
    {
        public EntityBaseResponse GetProyecto(int id)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var aplicativorepo = new AplicativoRepository();
                    var proyecto = new EntityProyecto();
                    const string sql = "usp_Obtener_Proyecto";

                    var p = new DynamicParameters();
                    p.Add(name: "@CODPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    proyecto = db.Query<EntityProyecto>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (proyecto != null)
                    {
                        proyecto.aplicativos = aplicativorepo.GetAplicativo(proyecto.codproyecto).data as List<EntityAplicativo>;
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = proyecto;
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

        public EntityBaseResponse GetProyectos()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var aplicativopro = new AplicativoRepository();
                    var projects = new List<EntityProyecto>();
                    const string sql = "usp_Listar_Proyectos";
                    projects = db.Query<EntityProyecto>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (projects.Count > 0)
                    {

                        foreach (var pro in projects)
                        {
                            pro.aplicativos = aplicativopro.GetAplicativo(pro.codproyecto).data as List<EntityAplicativo>;
                        }

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = projects;
                    }
                    else
                    {
                        response.issuccess = false;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = null;
                    }
                }
            } catch(Exception ex){
                response.issuccess = false;
                response.errorcode = "0001";
                response.errormensage = ex.Message;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse InsertarProyecto(EntityProyecto proyecto)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarProyecto";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODPROYECTO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NOMBREPROYECTO", value: proyecto.nombreproyecto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CODESTADO", value: proyecto.codestado, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@SOPORTE", value: proyecto.soporte, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@COORDINADOR", value: proyecto.coordinador, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CODSECTOR", value: proyecto.codsector, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: proyecto.direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@OBSERVACION", value: proyecto.observacion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CODTIPO", value: proyecto.codtipo, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query<EntityProyecto>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idproyecto = p.Get<int>("@CODPROYECTO");

                    if (idproyecto > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idproyecto,
                            nombre = proyecto.nombreproyecto
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
