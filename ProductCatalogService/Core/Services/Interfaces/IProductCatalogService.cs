using ProductCatalogService.Core.Entities;
using ProductCatalogService.Core.Services.DTOs;

namespace ProductCatalogService.Core.Services.Interfaces;

public interface IProductCatalogService
{
    public Task CreateProductCatalog(CreateProductCatalogDto productCatalog);
    public Task<IEnumerable<ProductCatalog>> ProductCatalogs();
    public Task<ProductCatalog> GetProductCatalogById(int id);
    public Task UpdateProductCatalog(int id, UpdateProductCatalogDto productCatalog);
    public Task DeleteProductCatalog(int id);
}