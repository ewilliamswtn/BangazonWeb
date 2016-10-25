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

        public IActionResult Activate()
        {
            string json = "{'result': 'true'}";
            return new ContentResult { Content = json, ContentType = "application/json" };
        }
    }
}
