using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Service.Abstraction.IServices;
using Shared.Dtos;

namespace Service.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper): IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<IEnumerable<ProductTypesDto>> GetProductTypesAsync()
        {
            var productTypes = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var productTypesDto = mapper.Map<IEnumerable<ProductTypesDto>>(productTypes);
            return productTypesDto;
        }

        public async Task<IEnumerable<ProductBrandsDto>> GetProductBrandsAsync()
        {
            var productBrands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var productBrandsDto = mapper.Map<IEnumerable<ProductBrandsDto>>(productBrands);
            return productBrandsDto;
        }
    }
}
