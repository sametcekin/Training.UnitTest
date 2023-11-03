using System.Linq.Expressions;
using Training.UnitTest.Data.Entities;

namespace Training.UnitTest.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<int> AddAsync(Product product);
        Task<Product> FindAsync(Expression<Func<Product, bool>>? predicate = null);
    }
}
