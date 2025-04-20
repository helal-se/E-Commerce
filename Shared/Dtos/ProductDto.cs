namespace Shared.Dtos
{
    public record ProductDto
    {
        public int Id;
        public string Name;
        public decimal Price;
        public string Description;
        public string PictureUrl;
        public string TypeName;
        public string BrandName;
    }
}