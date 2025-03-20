using EPizzaHub.Domain.Models;


namespace EPizzaHub.Repositories.Contracts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
      Task<Cart> GetCartDetailsAsync(Guid cartId);

        Task<bool> DeleteCartIDAsync(Guid CartId, int id);

    }
}
