namespace Domain.Entities.BasketModule
{
    public class CustomerBasket
    {
        public int Id { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; } = [];
    }
}
