using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightsRepository:IFlightRepository
    {

        private readonly FlightsContext _context;

        public IUnitOfWork unitOfWork { get { return _context; } } 
        public FlightsRepository(FlightsContext context)
        {
            _context = context; 
        }

        public Flight Add(Flight flight)
        {
            return _context.Flights.Add(flight).Entity;
        }

        public void Update(Flight flight)
        {
            _context.Flights.Update(flight);
        }

        public async Task<Flight> GetAsync(Guid flightId)
        {
            return await _context.Flights.FirstOrDefaultAsync(o => o.Id == flightId);
        }

        public Task<List<FlightDto>> SearchFlight(string code)
        {
            var result = _context.Flights.Join(_context.Airports,
                f => f.OriginAirportId,
                a => a.Id,
                (f, a) =>
                new {
                    f,
                    a
                }
                ).Join(_context.FlightRates,
                p => p.f.Id,
                r => r.Id,
                (p, r) => new {
                    p,
                    r
                }
                ).Where(x => x.p.a.Code == code).Select(y=>new
                FlightDto {
                    Arrival = y.p.f.Arrival,
                    ArrivalAirportCode= _context.Airports.Single(x => x.Id == y.p.f.DestinationAirportId).Code,
                    DepartureAirportCode=_context.Airports.Single(x=>x.Id==y.p.f.OriginAirportId).Code,
                    Departure=y.p.f.Departure,
                    Price=y.r.Price
                    
                }).OrderBy(o=>o.Price).ToList();

            return Task.FromResult(result);
        }
    }
}
