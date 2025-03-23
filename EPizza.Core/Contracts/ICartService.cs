using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Request;
using EPizzaHub.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Contracts
{
    public interface ICartService
    {
        Task<CartResponseModel> GetCartDetailsAysnc(Guid CartId);


        Task<bool> AddItemToCartAsync(AddToCartRequest request);

        Task<bool> DeleteItemsInCartAsync(Guid cartId, int ID);

        Task<bool> UpdateItemsInCartAsync(Guid cartId, int ID,int quantity);

        Task<int> GetItemCount(Guid CartId);


    }
}
