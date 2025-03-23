namespace EPizzaHub.UI.Models.ApiResponses
{

    public class GetCartResponseModel
    {
        public Guid Id { get; set; }

        public int Userid { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Total { get; set; }
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

        public string ImageUrl { get; set; }

        public string ItemName { get; set; }
        public decimal ItemTotal
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

    }

}
