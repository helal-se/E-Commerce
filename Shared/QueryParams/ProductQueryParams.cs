using System.Linq.Expressions;
using Domain.Entities;
using Shared.QueryParams.Enums;

namespace Shared.QueryParams
{
    public class ProductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public ProductSortingOptions SortingOptions { get; set; }
        public Expression<Func<Product, bool>> GetExpression()
        {
            return p => (!BrandId.HasValue || p.BrandId == BrandId) && (!TypeId.HasValue || p.TypeId == TypeId);
        }
    }
}
