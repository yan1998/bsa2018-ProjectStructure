using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Crews")]
    public class CrewsController : Controller
    {
        private readonly ICrewService crewService;

        public CrewsController(ICrewService crewService)
        {
            this.crewService = crewService;
        }

        // GET: api/Crews
        [HttpGet]
        public JsonResult Get()
        {
            return Json(crewService.GetAllCrews());
        }

        // GET: api/Crews/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(crewService.GetCrew(id));
        }
        
        // POST: api/Crews
        [HttpPost]
        public JsonResult Post([FromBody]CrewDTO value)
        {
            return Json(crewService.AddCrew(value));
        }
        
        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]CrewDTO crew)
        {
            try
            {
                return Json(crewService.UpdateCrew(id, crew));
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
                crewService.DeleteCrew(id);
            }
            catch (System.Exception)
            {
                HttpContext.Response.StatusCode = 404;
            }
        }
    }
}
