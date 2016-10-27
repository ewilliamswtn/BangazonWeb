using System.Linq;
using BangazonWeb.Data;
using BangazonWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BangazonWeb.Controllers
{
    public class CustomerController : Controller
    {
        private BangazonContext context;
        public CustomerController(BangazonContext ctx)
        {
            context = ctx;
        }

        public ActionResult Menu() {
            MenuViewModel model = new MenuViewModel(context);

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Activate([FromRoute]int id)
        {
            // Find the corresponding customer in the DB
            var customer = context.Customer.Single(c => c.CustomerId == id);

            // Return 404 if not found
            if (customer == null)
            {
                return NotFound();
            }

            // Set the active customer to the selected on
            ActiveCustomer.Instance.Customer = customer;

            return Json(customer);
        }
    }
}
