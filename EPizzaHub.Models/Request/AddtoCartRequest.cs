using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Models.Request
{
    public class AddtoCartRequest
    {
        public int Userid { get; set; }
        public Guid Cartid { get; set; }
        public int Itemid { get; set; }
        public decimal Unitprice { get; set; }
        public int Quantity { get; set; }
    }
}
