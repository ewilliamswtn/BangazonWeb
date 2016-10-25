using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using BangazonWeb.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangazonWeb.ViewModels
{
  public class BaseViewModel
  {
    public IEnumerable<SelectListItem> CustomerId { get; set; }
    private BangazonContext context;
    private ActiveCustomer singleton = ActiveCustomer.Instance;
    public Customer ChosenCustomer 
    {
      get
      {
        // Get the current value of the customer property of our singleton
        Customer customer = singleton.Customer;

        // If no customer has been chosen yet, it's value will be null
        if (customer == null)
        {
          // Return fake customer for now
          return new Customer () {
            FirstName = "Create",
            LastName = "Account"
          };
        }

        // If there is a customer chosen, return it
        return customer;
      }
      set
      {
        if (value != null)
        {
          singleton.Customer = value;
        }
      }
    }
    public BaseViewModel(BangazonContext ctx)
    {
        context = ctx;
        this.CustomerId = context.Customer
            .OrderBy(l => l.LastName)
            .AsEnumerable()
            .Select(li => new SelectListItem { 
                Text = $"{li.FirstName} {li.LastName}",
                Value = li.CustomerId.ToString()
            });
    }
    public BaseViewModel() { }
  }
}