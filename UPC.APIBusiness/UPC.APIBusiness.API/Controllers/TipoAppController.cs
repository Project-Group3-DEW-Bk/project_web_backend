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
    [Route("api/tipoapp")]
    public class TipoAppController : Controller
    {
        protected readonly ITipoAppRepository _tipoAppRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoAppRepository"></param>
        public TipoAppController(ITipoAppRepository tipoAppRepository)
        {
            _tipoAppRepository = tipoAppRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("gettipoapp")]
        public ActionResult GetTipoApp()
        {
            var ret = _tipoAppRepository.GetTipoApp();
            return Json(ret);
        }

    }
}
