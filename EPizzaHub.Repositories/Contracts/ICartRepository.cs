using EPizzaHub.Domain.Models;


namespace EPizzaHub.Repositories.Contracts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
      Task<Cart> GetCartDetailsAysnc(Guid cartId);
    }
}
