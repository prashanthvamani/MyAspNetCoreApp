using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Repositories.Concrete
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ePizzaHubDBContext dbContext) : base(dbContext)
        {
        }
    }
}
