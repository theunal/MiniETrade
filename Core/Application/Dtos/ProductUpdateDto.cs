namespace Application.Dtos
{
    public class ProductUpdateDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
