using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
  public class Product
  {
    [Key]
    public int ProductId {get;set;}

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreated {get;set;}

    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [Required]
    [StringLength(55)]
    public string Title { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public ICollection<LineItem> LineItems;
  }
}
