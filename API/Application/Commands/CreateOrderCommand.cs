using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public record CreateOrderCommand( Guid userId, int quantity , Guid flightId ): IRequest<Order>;
}
