using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Mappers
{
    public static class CartMappingExtension
    {
        public static CartResponseModel ConvertToCartResponseModel(
            this Cart cartdetails)
        {
            CartResponseModel response = new CartResponseModel();

            response.Id = cartdetails.Id;
            response.Userid = cartdetails.UserId;
            response.CreatedDate = cartdetails.CreatedDate;
            response.Items = cartdetails.CartItems.Select(
                x => new CartItemResponse
                {
                    Id = x.Id,
                    Itemid = x.ItemId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList();

            response.Total = response.Items.Sum(x => x.Quantity * x.UnitPrice);
            response.Tax = Math.Round(response.Total * 0.05m, 2);
            response.GrandTotal = response.Total + response.Tax;

            return response;
        }

    }
}
