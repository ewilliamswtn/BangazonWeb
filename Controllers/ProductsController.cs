using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Models;
using BangazonWeb.Data;
using BangazonWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BangazonWeb.Controllers
{
    public class ProductsController : Controller
    {
        private BangazonContext context;
        public ProductsController(BangazonContext ctx)
        {
            context = ctx;
        }

        public ActionResult Menu() {
            MenuViewModel model = new MenuViewModel(context);

            return PartialView(model);
        }

        public async Task<IActionResult> Index()
        {
            // Create new instance of the view model
            ProductList model = new ProductList(context);

            // Set the properties of the view model
            model.Products = await context.Product.ToListAsync(); 
            return View(model);
        }

        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            // Create new instance of view model
            ProductDetail model = new ProductDetail(context);

            // Set the `Product` property of the view model
            model.Product = await context.Product
                    .Include(prod => prod.Customer)
                    .SingleOrDefaultAsync(prod => prod.ProductId == id);

            // If product not found, return 404
            if (model.Product == null)
            {
                return NotFound();
            }

            return View(model); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            CustomerFormViewModel model = new CustomerFormViewModel(context);

            return View(model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Types()
        {
            return View(await context.ProductType.ToListAsync());
        }

        public IActionResult Types([FromRoute]int id)
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
