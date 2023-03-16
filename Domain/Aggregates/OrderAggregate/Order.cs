using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid userId { get; set; }
        public int quantity { get; set; }

        public Guid flightId { get; set; }

        public bool isComfirmed { get; set; }=false;

    }
}
