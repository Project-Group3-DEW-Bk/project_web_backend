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
    [Route("api/tipoproyecto")]
    public class TipoProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ITipoProyectoRepository _tipoProyectoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoProyectoRepository"></param>
        public TipoProyectoController(ITipoProyectoRepository tipoProyectoRepository)
        {
            _tipoProyectoRepository = tipoProyectoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("gettipoproyecto")]
        public ActionResult GetTipoProyecto()
        {
            var ret = _tipoProyectoRepository.GetTipoProyecto();
            return Json(ret);
        }
    }
}
