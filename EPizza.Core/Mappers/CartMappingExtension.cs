using Azure;
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
        public static CartResponseModel  ConverttoUserResponseModel(
           this Cart cartdetails)
        {
            CartResponseModel CartData = new CartResponseModel();

            CartData.Id = cartdetails.Id;
            CartData.UserId = cartdetails.UserId;
            CartData.CreatedDate = cartdetails.CreatedDate;
            CartData.Items = cartdetails.CartItems.Select(
                x => new CartItemFResponse
                {
                    Id = x.Id,
                    ItemId = x.ItemId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                }).ToList();
            CartData.Total = CartData.Items.Sum(x => x.Quantity * x.UnitPrice);
            CartData.Tax = Math.Round(CartData.Total * 0.05m, 2);
            CartData.Grandtotal = CartData.Total + CartData.Tax;

            return CartData;
        }
    }
}
