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
    [Route("api/aplicativo")]
    [ApiController]
    public class AplicativoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IAplicativoRepository _aplicativoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicativoRepository"></param>
        public AplicativoController(IAplicativoRepository aplicativoRepository)
        {
            _aplicativoRepository = aplicativoRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getaplicativos")]
        public ActionResult GetAplicativos()
        {
            var ret = _aplicativoRepository.GetAplicativos();
            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertarAplicativo(EntityAplicativo aplicativo)
        {
            var ret = _aplicativoRepository.InsertarAplicativo(aplicativo);
            return Json(ret);
        }

    }
}
