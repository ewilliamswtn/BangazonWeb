using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bangazon.Models;
using BangazonWeb.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangazonWeb.ViewModels
{
  public class CustomerFormViewModel : BaseViewModel
  {
    public List<SelectListItem> ProductTypeId { get; set; }
    public Product Product { get; set; }

    public Customer Customer 
    {
      get
      {
        return ActiveCustomer.Instance.Customer;
      }
    }
    public CustomerFormViewModel(BangazonContext ctx) : base(ctx) 
    { 

        this.ProductTypeId = ctx.ProductType
                                .OrderBy(l => l.Label)
                                .AsEnumerable()
                                .Select(li => new SelectListItem { 
                                    Text = li.Label,
                                    Value = li.ProductTypeId.ToString()
                                }).ToList();

        this.ProductTypeId.Insert(0, new SelectListItem { 
            Text = "Choose category...",
            Value = "0"
        }); 
    }
  }
}