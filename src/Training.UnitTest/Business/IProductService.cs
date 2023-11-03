using Training.UnitTest.Contracts;
using Training.UnitTest.Wrappers;

namespace Training.UnitTest.Business
{
    public interface IProductService
    {
        Task<Result<List<ProductDTO>>> GetAllAsync();
        Task<Result<int>> CreateAsync(ProductCreateDTO product);
    }
}
