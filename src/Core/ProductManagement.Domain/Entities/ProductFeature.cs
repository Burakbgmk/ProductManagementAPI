using ProductManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.Entities
{
    public class ProductFeature : BaseEntity
    {
        [Key]
        [ForeignKey("Product")]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal StockPrice { get; set; }
        public Product Product { get; set; }
    }
}
