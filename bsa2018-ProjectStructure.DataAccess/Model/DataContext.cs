using System;
using System.Collections.Generic;

namespace bsa2018_ProjectStructure.DataAccess.Model
{
    public class DataContext
    {
        public List<Aircraft> Aicrafts { get; set; }
        public List<AircraftType> AircraftTypes { get; set; }
        public List<Departure> Departures { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Stewardess> Stewardess { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Crew> Crews { get; set; }

        public DataContext()
        {
            LoadData();
        }

        private void LoadData()
        {
            #region AircraftType

            AircraftType aircraftType1 = new AircraftType
            {
                Id = 1,
                LoadCapacity = 70000,
                Places = 400
            };
            AircraftType aircraftType2 = new AircraftType
            {
                Id = 2,
                LoadCapacity = 2400,
                Places = 114
            };
            AircraftType aircraftType3 = new AircraftType
            {
                Id = 3,
                LoadCapacity = 20000,
                Places = 235
            };
            this.AircraftTypes = new List<AircraftType> { aircraftType1, aircraftType2, aircraftType3 };
            #endregion

            #region Aircrafts

            Aircraft aircraft1 = new Aircraft
            {
                Id = 1,
                Name = "Airbus A330",
                ReleaseDate = new DateTime(2010, 1, 17),
                LifeSpan = new TimeSpan(200, 0, 0, 0),
                AircraftType = aircraftType1,
                IdAircraftType = aircraftType1.Id
            };
            aircraftType1.Aircraft = aircraft1;

            Aircraft aircraft2 = new Aircraft
            {
                Id = 2,
                Name = "Boeing-737",
                ReleaseDate = new DateTime(2009, 6, 7),
                LifeSpan = new TimeSpan(157, 0, 0, 0),
                AircraftType = aircraftType2,
                IdAircraftType = aircraftType2.Id
            };
            aircraftType2.Aircraft = aircraft2;

            Aircraft aircraft3 = new Aircraft
            {
                Id = 3,
                Name = "Boeing-777",
                ReleaseDate = new DateTime(2009, 6, 7),
                LifeSpan = new TimeSpan(157, 0, 0, 0),
                AircraftType = aircraftType2,
                IdAircraftType = aircraftType2.Id
            };
            aircraftType3.Aircraft = aircraft3;
            this.Aicrafts = new List<Aircraft> { aircraft1, aircraft2, aircraft3 };
            #endregion

            #region Pilots

            Pilot pilot1 = new Pilot
            {
                Id = 1,
                Name = "Yan",
                Surname = "Gorshkov",
                Birthday = new DateTime(1998, 8, 21),
                Experience = 2
            };
            Pilot pilot2 = new Pilot
            {
                Id = 2,
                Name = "Vladimir",
                Surname = "Romanov",
                Birthday = new DateTime(1973, 1, 15),
                Experience = 6
            };
            this.Pilots = new List<Pilot> { pilot1, pilot2 };
            #endregion

            #region Stewardess

            Stewardess stewardess1 = new Stewardess
            {
                Id = 1,
                Name = "Anastasia",
                Surname = "Volkova",
                Birthday = new DateTime(1985, 9, 4)
            };
            Stewardess stewardess2 = new Stewardess
            {
                Id = 2,
                Name = "Anna",
                Surname = "Matveeva",
                Birthday = new DateTime(1992, 3, 28)
            };
            Stewardess stewardess3 = new Stewardess
            {
                Id = 3,
                Name = "Maria",
                Surname = "Mamedova",
                Birthday = new DateTime(1982, 2, 17)
            };
            this.Stewardess = new List<Stewardess> { stewardess1, stewardess2, stewardess3 };
            #endregion

            #region Crews

            Crew crew1 = new Crew
            {
                Id = 1,
                IdPilot = pilot1.Id,
                Pilot = pilot1,
                idStewardess = new List<int> { stewardess1.Id, stewardess2.Id },
            };
            Crew crew2 = new Crew
            {
                Id = 2,
                IdPilot = pilot2.Id,
                Pilot = pilot2,
                idStewardess = new List<int> { stewardess1.Id, stewardess3.Id }
            };
            Crew crew3 = new Crew
            {
                Id = 3,
                IdPilot = pilot2.Id,
                Pilot = pilot2,
                idStewardess = new List<int> { stewardess2.Id, stewardess3.Id }
            };
            this.Crews = new List<Crew> { crew1, crew2, crew3 };
            #endregion

            #region Flights

            Flight flight1 = new Flight
            {
                Id=1,
                ArrivalTime=new DateTime(2018,7,14,20,0,0),
                DeparturePlace="Odessa, Ukraine",
                Destination="Istambul, Turkey",
                DepartureTime=new DateTime(2018, 7, 13, 10, 30, 0) 
            };
            Flight flight2 = new Flight
            {
                Id = 2,
                ArrivalTime = new DateTime(2018, 7, 14, 5, 30, 0),
                DeparturePlace = "Odessa, Ukraine",
                Destination = "Vilnius, Lithuania",
                DepartureTime = new DateTime(2018, 7, 13, 23, 20, 0)
            };
            Flight flight3 = new Flight
            {
                Id = 3,
                ArrivalTime = new DateTime(2018, 7, 15, 22, 40, 0),
                DeparturePlace = "Batumi, Georgia",
                Destination = "Odessa, Ukraine",
                DepartureTime = new DateTime(2018, 7, 15, 14, 0, 0)
            };
            this.Flights = new List<Flight> { flight1, flight2, flight3 };
            #endregion

            #region Tickets
            Ticket ticket1 = new Ticket {
                Id=1,
                Cost=1000,
                Flight=flight1,
                IdFlight=flight1.Id
            };
            Ticket ticket2 = new Ticket
            {
                Id = 2,
                Cost = 1300,
                Flight = flight1,
                IdFlight = flight1.Id
            };
            Ticket ticket3 = new Ticket
            {
                Id = 3,
                Cost = 800,
                Flight = flight2,
                IdFlight = flight2.Id
            };
            Ticket ticket4 = new Ticket
            {
                Id = 4,
                Cost = 850,
                Flight = flight2,
                IdFlight = flight2.Id
            };
            Ticket ticket5 = new Ticket
            {
                Id = 5,
                Cost = 1000,
                Flight = flight3,
                IdFlight = flight3.Id
            };
            Ticket ticket6 = new Ticket
            {
                Id = 6,
                Cost = 1100,
                Flight = flight3,
                IdFlight = flight3.Id
            };
            this.Tickets = new List<Ticket> { ticket1, ticket2, ticket3, ticket4, ticket5, ticket6 };
            flight1.Tickets = new List<Ticket> { ticket1, ticket2 };
            flight2.Tickets = new List<Ticket> { ticket3, ticket4 };
            flight3.Tickets = new List<Ticket> { ticket5, ticket6 };
            #endregion

            #region Depatures
            Departure depature1 = new Departure {
                Id=1,
                Aircraft=aircraft1,
                IdAircraft=aircraft1.Id,
                Crew=crew1,
                IdCrew=crew1.Id,
                DepartureTime=new DateTime(2018, 7, 13, 11, 0, 0),
                Flight=flight1,
                IdFlight=flight1.Id
            };
            Departure depature2 = new Departure
            {
                Id = 2,
                Aircraft = aircraft2,
                IdAircraft = aircraft2.Id,
                Crew = crew2,
                IdCrew = crew2.Id,
                DepartureTime = new DateTime(2018, 7, 13, 23, 20, 0),
                Flight = flight2,
                IdFlight = flight2.Id
            };
            Departure depature3 = new Departure
            {
                Id = 3,
                Aircraft = aircraft3,
                IdAircraft = aircraft3.Id,
                Crew = crew3,
                IdCrew = crew3.Id,
                DepartureTime = new DateTime(2018, 7, 15, 14, 0, 0),
                Flight = flight3,
                IdFlight = flight3.Id
            };
            flight1.Departures = new List<Departure> { depature1 };
            flight2.Departures = new List<Departure> { depature2 };
            flight3.Departures = new List<Departure> { depature3 };
            this.Departures = new List<Departure> { depature1,depature2,depature3};
            #endregion
        }
    }
}
