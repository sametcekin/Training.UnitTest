using Training.UnitTest.Contracts;
using Training.UnitTest.Data.Entities;
using Training.UnitTest.Data.Repositories;
using Training.UnitTest.Wrappers;

namespace Training.UnitTest.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ProductDTO>>> GetAllAsync()
        {
            var productEntityList = await _repository.GetAllAsync();
            var productDTOList = productEntityList.Select(x => new ProductDTO
            {
                Id = x.Id,
                SKU = x.SKU,
                Price = x.Price
            }).ToList();

            return new Result<List<ProductDTO>>(productDTOList, "Products listed", true);
        }

        public async Task<Result<int>> CreateAsync(ProductCreateDTO product)
        {
            // Check product is exist
            if (await IsProductExist(product.SKU))
                return new Result<int>("Product is exist", false);

            var productEntity = new Product
            {
                SKU = product.SKU,
                Price = product.Price
            };

            var result = await _repository.AddAsync(productEntity);
            if (result == 0)
                return new Result<int>("Error", false);

            return new Result<int>(productEntity.Id, "Product is created", true);
        }

        public async Task<bool> IsProductExist(string sku)
        {
            var product = await _repository.FindAsync(x => x.SKU == sku);
            return product is not null;
        }
    }
}
