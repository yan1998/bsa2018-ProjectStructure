
using bsa2018_ProjectStructure.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using bsa2018_ProjectStructure.Shared.DTO;

namespace bsa2018_ProjectStructure.Controllers
{
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        private readonly IFlightService flightService;

        public FlightsController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        // GET: api/flights
        [HttpGet]
        public JsonResult Get()
        {
            return Json(flightService.GetAllFlights());
        }

        // GET: api/flights/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(flightService.GetFlight(id));
        }

        // POST api/flights
        [HttpPost]
        public JsonResult Post([FromBody]FlightDTO flight)
        {
            return Json(flightService.AddFlight(flight));
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]FlightDTO flight)
        {
            try
            {
                return Json(flightService.UpdateFlight(id, flight));
            }
            catch (System.Exception ex)
            {
                HttpContext.Response.StatusCode = 404;
                return Json(ex.Message);
            }
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                flightService.DeleteFlight(id);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 404;
            }
        }
    }
}