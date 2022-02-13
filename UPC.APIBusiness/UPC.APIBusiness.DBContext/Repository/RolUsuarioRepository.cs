using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class RolUsuarioRepository : BaseRepository, IRolUsuarioRepository
    {
        public EntityBaseResponse GetRolUsuario()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var rolusuario = new List<EntityRolUsuario>();
                    const string sql = "usp_Listar_RolUsuarios";
                    rolusuario = db.Query<EntityRolUsuario>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (rolusuario.Count > 0)
                    {

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = rolusuario;
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

        public EntityBaseResponse InsertarRolUsuario(EntityRolUsuario rolusuario)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarRolUsuarios";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODROL", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@DESROL", value: rolusuario.desrol, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityRolUsuario>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idrolusuario = p.Get<int>("CODROL");

                    if (idrolusuario > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idrolusuario,
                            nombre = rolusuario.desrol
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
