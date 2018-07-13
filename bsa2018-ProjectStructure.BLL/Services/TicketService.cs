using AutoMapper;
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
    public class TicketService:ITicketService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly TicketValidator validator;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            validator = new TicketValidator();
        }

        public TicketDTO AddTicket(TicketDTO ticket)
        {
            Validation(ticket);
            Ticket modelTicket = mapper.Map<TicketDTO, Ticket>(ticket);
            return mapper.Map<Ticket, TicketDTO>(unitOfWork.Tickets.Create(modelTicket));
        }

        public void DeleteTicket(int id)
        {
            try
            {
                unitOfWork.Tickets.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TicketDTO> GetAllTickets()
        {
            IEnumerable<Ticket> tickets = unitOfWork.Tickets.GetAll();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(tickets);
        }

        public TicketDTO GetTicket(int id)
        {
            Ticket ticket = unitOfWork.Tickets.GetById(id);
            return mapper.Map<Ticket, TicketDTO>(ticket);
        }

        public TicketDTO UpdateTicket(int id, TicketDTO ticket)
        {
            try
            {
                Validation(ticket);
                Ticket modelTicket = mapper.Map<TicketDTO, Ticket>(ticket);
                Ticket result = unitOfWork.Tickets.Update(id, modelTicket);
                return mapper.Map<Ticket, TicketDTO>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validation(TicketDTO ticket)
        {
            var validationResult = validator.Validate(ticket);
            if (!validationResult.IsValid)
                throw new Exception(validationResult.Errors.First().ToString());
        }
    }
}
