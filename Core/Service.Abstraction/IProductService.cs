using Shared.Dtos;
using Shared.QueryParams;

namespace Service.Abstraction.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(ProductQueryParams queryParams);
        Task<ProductDto> GetByIdAsync(int id);
    }
}