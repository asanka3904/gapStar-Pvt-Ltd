using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Query.SearchFlights
{
    public class SearchFlightsHandler : IRequestHandler<SearchFlightsQuery, List<FlightDto>>
    {

        private readonly IFlightRepository _flightRepository;

        public SearchFlightsHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
        }
        public async Task<List<FlightDto>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
        {
            var result = await _flightRepository.SearchFlight(request.code);
            

            return result;
        }

      
    }
}
