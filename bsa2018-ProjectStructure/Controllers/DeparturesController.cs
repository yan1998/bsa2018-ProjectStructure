using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        private readonly IDepartureService departureService;

        public DeparturesController(IDepartureService departureService)
        {
            this.departureService = departureService;
        }

        // GET: api/Departures
        [HttpGet]
        public JsonResult Get()
        {
            return Json(departureService.GetAllDepartures());
        }

        // GET: api/Departures/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            return Json(departureService.GetDeparture(id));
        }
        
        // POST: api/Departures
        [HttpPost]
        public JsonResult Post([FromBody]DepartureDTO departure)
        {
            return Json(departureService.AddDeparture(departure));
        }
        
        // PUT: api/Departures/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]DepartureDTO departure)
        {
            return Json(departureService.UpdateDeparture(id, departure));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            departureService.DeleteDeparture(id);
        }
    }
}
