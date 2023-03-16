using API.Application.ViewModels;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Query.SearchFlights
{
    public record SearchFlightsQuery(string code):IRequest<List<FlightDto>>;
}
