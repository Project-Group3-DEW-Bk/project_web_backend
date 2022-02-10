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
    [Route("api/proyecto")]
    [ApiController]
    public class ProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProyectoRepository _proyectoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proyectoRepository"></param>
        public ProyectoController(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproyectos")]
        public ActionResult GetProyectos()
        {
            var ret = _proyectoRepository.GetProyectos();
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproyecto")]
        public ActionResult GetProyecto(int id)
        {
            var ret = _proyectoRepository.GetProyecto(id);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertarProyecto(EntityProyecto proyecto)
        {
            var ret = _proyectoRepository.InsertarProyecto(proyecto);
            return Json(ret);
        }
    }
}
