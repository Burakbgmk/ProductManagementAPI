using ProductManagement.Domain.Common;

namespace ProductManagement.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature Feature { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    }
}
