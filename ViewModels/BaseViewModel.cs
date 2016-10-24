using Bangazon.Models;
using BangazonWeb.Data;

namespace BangazonWeb.ViewModels
{
  public class BaseViewModel
  {
    private ActiveCustomer singleton = ActiveCustomer.Instance;
    public Customer ChosenCustomer 
    {
      get
      {
        Customer customer = singleton.Customer;
        if (customer == null)
        {
          return new Customer(){
            FirstName = "Create",
            LastName = "Account"
          };
        }
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

  }
  
}