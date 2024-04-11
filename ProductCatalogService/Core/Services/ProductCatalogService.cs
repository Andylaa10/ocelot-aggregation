using AutoMapper;
using ProductCatalogService.Core.Entities;
using ProductCatalogService.Core.Repositories.Interfaces;
using ProductCatalogService.Core.Services.DTOs;
using ProductCatalogService.Core.Services.Interfaces;

namespace ProductCatalogService.Core.Services;

public class ProductCatalogService : IProductCatalogService
{
    private readonly IProductCatalogRepository _productCatalogRepository;
    private readonly IMapper _mapper;

    public ProductCatalogService(IProductCatalogRepository productCatalogRepository, IMapper mapper)
    {
        _productCatalogRepository = productCatalogRepository;
        _mapper = mapper;
    }

    public async Task CreateProductCatalog(CreateProductCatalogDto productCatalog)
    {
        await _productCatalogRepository.CreateProductCatalog(_mapper.Map<ProductCatalog>(productCatalog));
    }

    public async Task<IEnumerable<ProductCatalog>> ProductCatalogs()
    {
        return await _productCatalogRepository.ProductCatalogs();
    }

    public async Task<ProductCatalog> GetProductCatalogById(int id)
    {
        if (id < 1) throw new ArgumentException("Id cannot be less 1");

        return await _productCatalogRepository.GetProductCatalogById(id) ?? throw new ArgumentException($"No product catalog with the id of {id}");
    }

    public async Task UpdateProductCatalog(int id, UpdateProductCatalogDto productCatalog)
    {
        var update = await _productCatalogRepository.DoesProductCatalogExist(id);
        if (id < 1) throw new ArgumentException("Id cannot be less 1");
        if (!update) throw new ArgumentException($"No such product catalog with the id of {id}");
        if (id != productCatalog.Id) throw new ArgumentException("Id in the route does not match with the product catalog id");

        await _productCatalogRepository.UpdateProductCatalog(id, _mapper.Map<ProductCatalog>(productCatalog));
    }

    public async Task DeleteProductCatalog(int id)
    {
        var order = await _productCatalogRepository.DoesProductCatalogExist(id);
        if (!order) throw new ArgumentException($"No such product catalog with the id of {id}");
        if (id < 1) throw new ArgumentException("Id cannot be less than 1");

        await _productCatalogRepository.DeleteProductCatalog(id);
    }
}