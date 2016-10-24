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
            MenuViewModel model = new MenuViewModel();

            return PartialView(model);
        }

        public async Task<IActionResult> Index()
        {
            // Create new instance of the view model
            ProductList model = new ProductList();

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
            ProductDetail model = new ProductDetail();

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
            ViewData["ProductTypeId"] = context.ProductType
                                       .OrderBy(l => l.Label)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = li.Label,
                                           Value = li.ProductTypeId.ToString()
                                        });

            ViewData["CustomerId"] = context.Customer
                                       .OrderBy(l => l.LastName)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = $"{li.FirstName} {li.LastName}",
                                           Value = li.CustomerId.ToString()
                                        });

            return View(); 
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
