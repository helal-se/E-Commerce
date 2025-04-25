using Domain.Entities;

namespace Service.Specifications
{
    class ProductSpecification : Specification<Product, int>
    {
        public ProductSpecification(int? id = null) : base(id.HasValue ? product => product.Id == id.Value : null)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
    }
}
