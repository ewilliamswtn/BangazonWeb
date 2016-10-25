using System.Linq;
using System.Threading.Tasks;
using BangazonWeb.Data;
using BangazonWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Activate([FromBody]int CustomerId)
        {
          var customer = context.Customer.SingleOrDefault(c => c.CustomerId == CustomerId);

          if (customer == null)
          {
            return NotFound();
          }

          ActiveCustomer.Instance.Customer = customer;





          string json = "{'result': 'true'}";
          return new ContentResult { Content = json, ContentType = "application/json" };
        }
    }
}
