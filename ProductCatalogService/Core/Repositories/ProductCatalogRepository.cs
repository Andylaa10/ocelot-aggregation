using ProductCatalogService.Core.Entities;
using ProductCatalogService.Core.Repositories.Interfaces;

namespace ProductCatalogService.Core.Repositories;

public class ProductCatalogRepository : IProductCatalogRepository
{
    private readonly List<ProductCatalog> _productCatalogs = new()
    {
        new ProductCatalog
        {
            Id = 1,
            Color = "Black",
            Description = "Black",
            Cost = 100.0f,
            Name = "Black",
            CreatedAt = DateTime.Now
        },
        new ProductCatalog
        {
            Id = 2,
            Color = "Yellow",
            Description = "Yellow",
            Cost = 50.0f,
            Name = "Yellow",
            CreatedAt = DateTime.Now.AddHours(1)
        },
        new ProductCatalog
        {
            Id = 3,
            Color = "Green",
            Description = "Green",
            Cost = 35.0f,
            Name = "Green",
            CreatedAt = DateTime.Now.AddHours(2)
        },
        new ProductCatalog
        {
            Id = 4,
            Color = "Red",
            Description = "Red",
            Cost = 250.0f,
            Name = "Red",
            CreatedAt = DateTime.Now.AddHours(3)
        },
        new ProductCatalog
        {
            Id = 5,
            Color = "White",
            Description = "White",
            Cost = 500.0f,
            Name = "White",
            CreatedAt = DateTime.Now.AddHours(4)
        }
    };

    public async Task CreateProductCatalog(ProductCatalog productCatalog)
    {
        await Task.Run(() => { _productCatalogs.Add(productCatalog); });

    }

    public async Task<IEnumerable<ProductCatalog>> ProductCatalogs()
    {
        return await Task.Run(() => _productCatalogs.AsQueryable());
    }

    public async Task<ProductCatalog> GetProductCatalogById(int id)
    {
        var productCatalog = _productCatalogs.Find(p => p.Id == id) ?? throw new ArgumentException($"No product catalogs with the id of {id}");
        
        return await Task.FromResult(productCatalog);
    }

    public async Task UpdateProductCatalog(int id, ProductCatalog productCatalog)
    {
        var update = _productCatalogs.Find(p => p.Id == id) ?? throw new ArgumentException($"No product catalogs with the id of {id}");

        await Task.Run(() =>
        {
            update.Color = productCatalog.Color;
            update.Cost = productCatalog.Cost;
            update.Description = productCatalog.Description;
            update.Name = productCatalog.Name;
            update.UpdatedAt = DateTime.Now;
        });
    }

    public async Task DeleteProductCatalog(int id)
    {
        var productCatalog = _productCatalogs.Find(p => p.Id == id) ?? throw new ArgumentException($"No product catalog with the id of {id}");

        var index = _productCatalogs.IndexOf(productCatalog);
        
        await Task.Run(()=> _productCatalogs.RemoveAt(index));
    }

    public async Task<bool> DoesProductCatalogExist(int id)
    {
        var order = _productCatalogs.Find(p => p.Id == id);

        if (order == null) await Task.Run(() => false);
        return await Task.Run(() => true);
    }
}