using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Models.Response
{
    public class CartResponseModel
    {
        public Guid Id { get; set; }

        public int Userid { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Total {  get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Tax { get; set; }

        public List<CartItemResponse> Items { get; set; }
    }

    public class CartItemResponse
    {
        public int Id { get; set; }

        public int Itemid { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
