using EPizzaHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Contracts
{
    public interface ICartService
    {
        Task<CartItem> GetCartItemAsync(Guid CartId);
    }
}
