using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public record ConfirmOrderCommad(Guid orderid):IRequest<Order>;
}
