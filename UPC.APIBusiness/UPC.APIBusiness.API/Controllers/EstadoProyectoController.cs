using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;


namespace API
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/estadoproyecto")]
    public class EstadoProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IEstadoProyectoRepository _estadoProyectoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estadoProyectoRepository"></param>
        public EstadoProyectoController(IEstadoProyectoRepository estadoProyectoRepository)
        {
            _estadoProyectoRepository = estadoProyectoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getestadoproyecto")]
        public ActionResult GetEstadoProyecto()
        {
            var ret = _estadoProyectoRepository.GetEstadoProyecto();
            return Json(ret);
        }

    }
}
