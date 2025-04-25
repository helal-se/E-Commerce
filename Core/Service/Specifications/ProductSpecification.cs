using Domain.Entities;
using Shared.QueryParams;

namespace Service.Specifications
{
    class ProductSpecification : Specification<Product, int>
    {
        
        public ProductSpecification(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        public ProductSpecification(ProductQueryParams queryParams): base(queryParams.GetExpression())
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
    }
}
