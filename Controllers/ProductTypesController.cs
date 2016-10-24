using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Models;
using BangazonWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BangazonWeb.Controllers
{
    public class ProductTypesController : Controller
    {
        private BangazonContext context;

        public ProductTypesController(BangazonContext ctx)
        {
            context = ctx;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag["types"] = from t in context.ProductType
            join p in context.Product
            on t.ProductTypeId equals p.ProductTypeId
            group new { t, p } by new { t.Label } into grouped
            select new {
              TypeName = grouped.Key.Label,
              ProductCount = grouped.Select(x => x.p.ProductId).Count()
            };
            
            return View();
        }

        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            var types = await context.ProductType
                    .Include(t => t.Products)
                    .SingleOrDefaultAsync(t => t.ProductTypeId == id);

            // If product not found, return 404
            if (types == null)
            {
                return NotFound();
            }

            return View(types);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }
    }
}
