using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {

        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public int quantity { get; set; }

        public Guid flightId { get; set; }

        public bool isComfirmed { get; set; }
    }
}
