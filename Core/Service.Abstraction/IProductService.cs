using Shared.Dtos;

namespace Service.Abstraction.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
    }
}