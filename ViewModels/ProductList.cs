using System.Collections.Generic;
using Bangazon.Models;
using BangazonWeb.Data;

namespace BangazonWeb.ViewModels
{
  public class ProductList : BaseViewModel
  {
    public IEnumerable<Product> Products { get; set; }
    public ProductList(BangazonContext ctx) : base(ctx) { }
  }
}