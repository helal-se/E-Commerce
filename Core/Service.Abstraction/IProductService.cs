using Shared.Dtos;

namespace Service.Abstraction.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);

        Task<IEnumerable<ProductTypesDto>> GetProductTypesAsync();
        Task<IEnumerable<ProductBrandsDto>> GetProductBrandsAsync();

    }
}