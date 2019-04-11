using System;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OrderSystem.Models;



namespace OrderSystem.Controllers
{
    public class ProductController : Controller
    {

        OrderingSystemContext _context;

        public ProductController(OrderingSystemContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Category()
        {
            var categories = _context.Category_Detail.ToList();
            ViewData["categories"] = categories;

            return View();
        }


      /*  [HttpGet]
        public IActionResult SubCategory()
        {
            var subcategories = _context.Sub_Category_Details.ToList();
            ViewData["subcategories"] = subcategories;

            return View();
        }*/



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
