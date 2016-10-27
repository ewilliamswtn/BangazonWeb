using Bangazon.Models;
using BangazonWeb.Data;

namespace BangazonWeb.ViewModels
{
  public class ProductDetail : BaseViewModel
  {
    public Product Product { get; set; }
    public ProductDetail(BangazonContext ctx) : base(ctx) { }
    }
}