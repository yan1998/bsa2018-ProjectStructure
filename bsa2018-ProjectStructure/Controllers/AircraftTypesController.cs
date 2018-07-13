using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/AircraftTypes")]
    public class AircraftTypesController : Controller
    {
        private readonly IAircraftTypesService aircraftTypesService;

        public AircraftTypesController(IAircraftTypesService aircraftTypesService)
        {
            this.aircraftTypesService = aircraftTypesService;
        }

        // GET: api/AircraftTypes
        [HttpGet]
        public JsonResult Get()
        {
            return Json(aircraftTypesService.GetAllAircraftTypes());
        }

        // GET: api/AircraftTypes/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(aircraftTypesService.GetAircraftType(id));
        }
        
        // POST: api/AircraftTypes
        [HttpPost]
        public JsonResult Post([FromBody]AircraftTypeDTO aircraftType)
        {
            return Json(aircraftTypesService.AddAircraftType(aircraftType));
        }
        
        // PUT: api/AircraftTypes/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]AircraftTypeDTO aircraftType)
        {
            try
            {
                return Json(aircraftTypesService.UpdateAircraftType(id, aircraftType));
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
                aircraftTypesService.DeleteAircraftType(id);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 404;
            }

        }
    }
}
