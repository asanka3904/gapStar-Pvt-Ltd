using API.Application.ViewModels;
using AutoMapper;
using Core.Flights.Query.SearchFlights;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;

namespace API.Mapping
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<Airport, AirportViewModel>();
            
        }
    }
}