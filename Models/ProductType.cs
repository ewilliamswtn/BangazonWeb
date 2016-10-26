using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
  public class ProductType
  {
    [Key]
    public int ProductTypeId { get; set; }

    [Required]
    [StringLength(255)]
    [Display(Name="Category")]
    public string Label { get; set; }
    public ICollection<Product> Products;
  }
}
