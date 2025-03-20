﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Models.Request
{
    public class AddToCartRequest
    {
        public int UserId { get; set; }

        public Guid CartId { get; set; }

        public int ItemId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
