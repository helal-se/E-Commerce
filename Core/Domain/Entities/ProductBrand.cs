namespace Domain.Entities
{
    public class ProductBrand: BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
