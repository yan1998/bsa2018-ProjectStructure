using bsa2018_ProjectStructure.DataAccess.Model;

namespace bsa2018_ProjectStructure.Shared.DTO
{
    public class MapperConfiguration
    {
        public AutoMapper.MapperConfiguration Configure()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aircraft, AircraftDTO>();
                cfg.CreateMap<AircraftDTO, Aircraft>()
                    .ForMember(a => a.Departures, opt => opt.Ignore())
                    .ForMember(a => a.AircraftType, opt => opt.Ignore());

                cfg.CreateMap<AircraftType, AircraftTypeDTO>();
                cfg.CreateMap<AircraftTypeDTO, AircraftType>()
                    .ForMember(a => a.Aircraft, opt => opt.Ignore());

                cfg.CreateMap<Crew, CrewDTO>();
                cfg.CreateMap<CrewDTO, Crew>()
                    .ForMember(c => c.Pilot, opt => opt.Ignore());

                cfg.CreateMap<Departure, DepartureDTO>()
                    .ForMember(d=>d.FlightNumber,opt=>opt.MapFrom(d=>d.IdFlight));
                cfg.CreateMap<DepartureDTO, Departure>()
                    .ForMember(d=>d.IdFlight, opt=>opt.MapFrom(d=>d.FlightNumber))
                    .ForMember(d => d.Aircraft, opt => opt.Ignore())
                    .ForMember(d => d.Crew, opt => opt.Ignore())
                    .ForMember(d => d.Flight, opt => opt.Ignore());

                cfg.CreateMap<Flight, FlightDTO>()
                    .ForMember(f => f.Number, opt => opt.MapFrom(f => f.Id));
                cfg.CreateMap<FlightDTO, Flight>()
                    .ForMember(f=>f.Id, opt=>opt.MapFrom(f=>f.Number))
                    .ForMember(f => f.Departures, opt => opt.Ignore())
                    .ForMember(f => f.Tickets, opt => opt.Ignore());

                cfg.CreateMap<Pilot, PilotDTO>();
                cfg.CreateMap<PilotDTO, Pilot>();

                cfg.CreateMap<Stewardess, StewardessDTO>();
                cfg.CreateMap<StewardessDTO, Stewardess>();

                cfg.CreateMap<Ticket, TicketDTO>()
                    .ForMember(t=>t.FlightNumber, opt=>opt.MapFrom(t=>t.IdFlight));
                cfg.CreateMap<TicketDTO, Ticket>()
                    .ForMember(t=>t.IdFlight, opt=>opt.MapFrom(t=>t.FlightNumber))
                    .ForMember(t=>t.Flight, opt=>opt.Ignore());
            });

            return config;
        }
    }
}
