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
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            return Json(aircraftService.GetAircraft(id));
        }
        
        // POST: api/Aircrafts
        [HttpPost]
        public JsonResult Post([FromBody]AircraftDTO aircraft)
        {
            return Json(aircraftService.AddAircraft(aircraft));
        }
        
        // PUT: api/Aircrafts/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]AircraftDTO aircraft)
        {
            return Json(aircraftService.UpdateAircraft(id,aircraft));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            aircraftService.DeleteAircraft(id);
        }
    }
}
