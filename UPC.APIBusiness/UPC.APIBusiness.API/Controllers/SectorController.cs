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
    [Route("api/sector")]
    [ApiController]
    public class SectorController : Controller
    {
        protected readonly ISectorRepository _sectorRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectorRepository"></param>
        public SectorController(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getsector")]
        public ActionResult GetSector()
        {
            var ret = _sectorRepository.GetSector();
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertarSector(EntitySector sector)
        {
            var ret = _sectorRepository.InsertarSector(sector);
            return Json(ret);
        }

    }
}
