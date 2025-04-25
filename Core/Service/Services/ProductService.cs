using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Service.Abstraction.IServices;
using Service.Specifications;
using Shared.Dtos;
using Shared.QueryParams;

namespace Service.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper): IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllAsync(ProductQueryParams queryParams)
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(new ProductSpecification(queryParams));
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            //var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(new ProductSpecification(id));
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
