using ProductCatalogService.Core.Entities;

namespace ProductCatalogService.Core.Repositories.Interfaces;

public interface IProductCatalogRepository
{
    public Task CreateProductCatalog(ProductCatalog productCatalog);
    public Task<IEnumerable<ProductCatalog>> ProductCatalogs();
    public Task<ProductCatalog> GetProductCatalogById(int id);
    public Task UpdateProductCatalog(int id, ProductCatalog productCatalog);
    public Task DeleteProductCatalog(int id);
    public Task<bool> DoesProductCatalogExist(int id);
}