﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.Shared.DTO;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("{id}", Name = "Get")]
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
            return Json(aircraftTypesService.UpdateAircraftType(id,aircraftType));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            aircraftTypesService.DeleteAircraftType(id);
        }
    }
}