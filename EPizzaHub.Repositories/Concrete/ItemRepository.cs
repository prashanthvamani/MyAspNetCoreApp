using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;


namespace EPizzaHub.Repositories.Concrete
{
    public class ItemRepository : GenericRepository<Item>, IitemRepository
    {
        public ItemRepository(ePizzaHubDBContext dbContext) : base(dbContext)
        {
        }
    }
}
