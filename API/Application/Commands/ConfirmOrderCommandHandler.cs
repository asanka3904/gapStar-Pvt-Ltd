using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommad, Order>
    {

        private readonly IOrderRepository _orderRepository;
        public ConfirmOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository; 
        }
        public async Task<Order> Handle(ConfirmOrderCommad request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.orderid);
            order.isComfirmed = true;

            _orderRepository.Update(order);
            Console.WriteLine($"Notification: The order of  {order.Id} is confirmed");

            return order;
        }
    }
}
