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
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total {  get; set; }
        public decimal Tax {  get; set; }
        public decimal Grandtotal { get; set; }

        public List<CartItemFResponse> Items { get; set; }
    }

    public class CartItemFResponse
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
