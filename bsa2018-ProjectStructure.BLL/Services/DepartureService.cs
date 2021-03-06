﻿using AutoMapper;
using bsa2018_ProjectStructure.BLL.Interfaces;
using bsa2018_ProjectStructure.BLL.Validators;
using bsa2018_ProjectStructure.DataAccess.Interfaces;
using bsa2018_ProjectStructure.DataAccess.Model;
using bsa2018_ProjectStructure.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bsa2018_ProjectStructure.BLL.Services
{
    public class DepartureService:IDepartureService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly DepartureValidator validator;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new DepartureValidator();
        }

        public DepartureDTO AddDeparture(DepartureDTO departure)
        {
            Validation(departure);
            Departure modelDeparture = mapper.Map<DepartureDTO, Departure>(departure);
            return mapper.Map<Departure, DepartureDTO>(unitOfWork.Departures.Create(modelDeparture));
        }

        public void DeleteDeparture(int id)
        {
            try
            {
                unitOfWork.Departures.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DepartureDTO> GetAllDepartures()
        {
            IEnumerable<Departure> departures = unitOfWork.Departures.GetAll();
            return mapper.Map<IEnumerable<Departure>, List<DepartureDTO>>(departures);
        }

        public DepartureDTO GetDeparture(int id)
        {
            Departure departure = unitOfWork.Departures.GetById(id);
            return mapper.Map<Departure, DepartureDTO>(departure);
        }

        public DepartureDTO UpdateDeparture(int id, DepartureDTO departure)
        {
            try
            {
                Validation(departure);
                Departure modelDeparture = mapper.Map<DepartureDTO, Departure>(departure);
                Departure result = unitOfWork.Departures.Update(id, modelDeparture);
                return mapper.Map<Departure, DepartureDTO>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(DepartureDTO departure)
        {
            var validationResult = validator.Validate(departure);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
