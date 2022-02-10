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

        public EntityBaseResponse GetAplicativos()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    
                    var aplicativos = new List<EntityAplicativo>();
                    const string sql = "usp_Listar_Aplicativos";
                    aplicativos = db.Query<EntityAplicativo>(
                        sql: sql,
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

        public EntityBaseResponse InsertarAplicativo(EntityAplicativo aplicativo)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarAplicativo";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODAPLICATIVO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NOMBREAPLICATIVO", value: aplicativo.nombreaplicativo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@TIPOUSO", value: aplicativo.tipouso, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CODTIPOAPP", value: aplicativo.codtipoapp, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@CODPROYECTO", value: aplicativo.codproyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    db.Query<EntityAplicativo>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idaplicativo = p.Get<int>("@CODAPLICATIVO");

                    if (idaplicativo > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idaplicativo,
                            nombre = aplicativo.nombreaplicativo
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
