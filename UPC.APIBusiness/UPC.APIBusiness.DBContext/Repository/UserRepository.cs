using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public EntityBaseResponse Insert(EntityUser user)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarUsuario";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODUSUARIO", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@@USUARIO", value: user.usuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTRASENIA", value: user.contrasenia, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CODPERFIL", value: user.codrol, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@NOMBRESUSUARIO", value: user.nombreusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@ESTADOUSUARIO", value: user.estadousuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    
                    db.Query<EntityUser>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idusuario = p.Get<int>("@CODUSUARIO");

                    if (idusuario > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idusuario,
                            nombre = user.nombreusuario
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

        public EntityBaseResponse ListadoUsuario()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var aplicativopro = new AplicativoRepository();
                    var users = new List<EntityUser>();
                    const string sql = "usp_Listar_Usuarios";
                    users = db.Query<EntityUser>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (users.Count > 0)
                    {

                       

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = users;
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

        public EntityBaseResponse Login(EntityLogin login)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var user = new EntityLoginResponse();
                    const string sql = "usp_user_login";

                    var p = new DynamicParameters();
                    p.Add(name: "@LOGINUSUARIO", value: login.uid, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@PASSWORDUSUARIO", value: login.pwd, dbType: DbType.String, direction: ParameterDirection.Input);

                    user = db.Query<EntityLoginResponse>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (user != null)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = user;
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
