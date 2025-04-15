namespace Domain.Entities
{
    public class Product: BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        // Navigation Properties
        public int TypeId { get; set; }
        public int BrandId { get; set; }

        public ProductBrand ProductBrand { get; set; } = default!;
        public ProductType ProductType { get; set; } = default!;
    }
}
