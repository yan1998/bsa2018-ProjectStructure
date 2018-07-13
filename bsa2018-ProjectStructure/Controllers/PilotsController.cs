using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        private readonly IPilotService pilotService;

        public PilotsController(IPilotService pilotService)
        {
            this.pilotService = pilotService;
        }

        // GET: api/Pilots
        [HttpGet]
        public JsonResult Get()
        {
            return Json(pilotService.GetAllPilots());
        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(pilotService.GetPilot(id));
        }
        
        // POST: api/Pilots
        [HttpPost]
        public JsonResult Post([FromBody]PilotDTO pilot)
        {
            return Json(pilotService.AddPilot(pilot));
        }
        
        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]PilotDTO pilot)
        {
            try
            {
                return Json(pilotService.UpdatePilot(id, pilot));
            }
            catch (System.Exception ex)
            {
                HttpContext.Response.StatusCode = 404;
                return Json(ex.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                pilotService.DeletePilot(id);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
