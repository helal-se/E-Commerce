using System.Linq.Expressions;
using Domain.Entities;
using Shared.QueryParams.Enums;

namespace Shared.QueryParams
{
    public class ProductQueryParams
    {
        public string? Search { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }


        public ProductSortingOptions SortingOptions { get; set; }
        public Expression<Func<Product, bool>> GetExpression()
        {
            return p => 
                (!TypeId.HasValue || p.TypeId == TypeId) &&
                (!BrandId.HasValue || p.BrandId == BrandId) &&
                (string.IsNullOrEmpty(Search) || p.Name.ToLower().Contains(Search));
        }
    }
}
