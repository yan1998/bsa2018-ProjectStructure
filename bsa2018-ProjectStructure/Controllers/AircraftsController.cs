using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Aircrafts")]
    public class AircraftsController : Controller
    {
        private readonly IAircraftService aircraftService;

        public AircraftsController(IAircraftService aircraftService)
        {
            this.aircraftService = aircraftService;
        }

        // GET: api/Aircrafts
        [HttpGet]
        public JsonResult Get()
        {
            return Json(aircraftService.GetAllAircrafts());
        }

        // GET: api/Aircrafts/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(aircraftService.GetAircraft(id));
        }
        
        // POST: api/Aircrafts
        [HttpPost]
        public JsonResult Post([FromBody]AircraftDTO aircraft)
        {
            try
            {
                return Json(aircraftService.AddAircraft(aircraft));
            }
            catch (System.Exception ex)
            {
                HttpContext.Response.StatusCode = 400;
                return Json(ex.Message);
            }
        }
        
        // PUT: api/Aircrafts/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]AircraftDTO aircraft)
        {
            try
            {
                return Json(aircraftService.UpdateAircraft(id, aircraft));
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
                aircraftService.DeleteAircraft(id);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
