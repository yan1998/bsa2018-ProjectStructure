﻿using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bsa2018_ProjectStructure.Controllers
{
    [Produces("application/json")]
    [Route("api/Stewardess")]
    public class StewardessController : Controller
    {
        private readonly IStewardessService stewardessService;

        public StewardessController(IStewardessService stewardessService)
        { 
            this.stewardessService = stewardessService;
        }

        // GET: api/Stewardess
        [HttpGet]
        public JsonResult Get()
        {
            return Json(stewardessService.GetAllStewardess());
        }

        // GET: api/Stewardess/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            return Json(stewardessService.GetStewardess(id));
        }
        
        // POST: api/Stewardess
        [HttpPost]
        public JsonResult Post([FromBody]StewardessDTO stewardess)
        {
            return Json(stewardessService.AddStewardess(stewardess));
        }
        
        // PUT: api/Stewardess/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]StewardessDTO stewardess)
        {
            return Json(stewardessService.UpdateStewardess(id, stewardess));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            stewardessService.DeleteStewardess(id);
        }
    }
}
