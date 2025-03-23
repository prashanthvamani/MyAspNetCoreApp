namespace EPizzaHub.UI.Models.APIRequests
{
    public class AddToCartRequest
    {

        public int Userid { get; set; }
        public Guid Cartid { get; set; }
        public int Itemid { get; set; }
        public decimal Unitprice { get; set; }
        public int Quantity { get; set; }

    }
}
