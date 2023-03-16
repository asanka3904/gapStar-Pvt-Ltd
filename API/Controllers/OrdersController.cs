using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<OrdersController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);

            return Ok(_mapper.Map<OrderViewModel>(order));
        }

        [HttpPut]
        [Route("confimOrder")]
        public async Task<IActionResult> Create(Guid orderId)
        {
            var order = await _mediator.Send(orderId);

            return Ok(_mapper.Map<OrderViewModel>(order));
        }
    }
}
