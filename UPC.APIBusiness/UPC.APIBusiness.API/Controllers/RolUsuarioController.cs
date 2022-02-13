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
    [Route("api/rolusuario")]
    [ApiController]
    public class RolUsuarioController : Controller
    {
        protected readonly IRolUsuarioRepository _rolusuarioRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolusuarioRepository"></param>
        public RolUsuarioController(IRolUsuarioRepository rolusuarioRepository)
        {
            _rolusuarioRepository = rolusuarioRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getrolusuario")]
        public ActionResult GetRolUsuario()
        {
            var ret = _rolusuarioRepository.GetRolUsuario();
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolusuario"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertarRolUsuario(EntityRolUsuario rolusuario)
        {
            var ret = _rolusuarioRepository.InsertarRolUsuario(rolusuario);
            return Json(ret);
        }

    }
}
