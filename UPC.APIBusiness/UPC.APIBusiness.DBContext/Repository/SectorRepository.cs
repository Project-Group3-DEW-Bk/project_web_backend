using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using DBEntity;
using Dapper;

namespace DBContext
{
    public class SectorRepository : BaseRepository, ISectorRepository
    {
        public EntityBaseResponse GetSector()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {

                    var sector = new List<EntitySector>();
                    const string sql = "usp_Listar_Sector";
                    sector = db.Query<EntitySector>(
                        sql: sql,
                        commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (sector.Count > 0)
                    {

                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = string.Empty;
                        response.data = sector;
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

        public EntityBaseResponse InsertarSector(EntitySector sector)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_InsertarSector";
                    var p = new DynamicParameters();

                    p.Add(name: "@CODSECTOR", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@NOMBRESECTOR", value: sector.nombresector, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntitySector>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    var idsector= p.Get<int>("@CODSECTOR");

                    if (idsector > 0)
                    {
                        response.issuccess = true;
                        response.errorcode = "0000";
                        response.errormensage = String.Empty;
                        response.data = new
                        {
                            id = idsector,
                            nombre = sector.nombresector
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
