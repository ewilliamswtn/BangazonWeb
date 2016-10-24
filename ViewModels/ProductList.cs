using System.Collections.Generic;
using Bangazon.Models;

namespace BangazonWeb.ViewModels
{
  public class ProductList : BaseViewModel
  {
    public IEnumerable<Product> Products { get; set; }
  }
}