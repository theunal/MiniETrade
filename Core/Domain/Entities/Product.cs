namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
