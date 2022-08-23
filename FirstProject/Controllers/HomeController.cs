using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FirstProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirstProjectContext _firstProjectContext;
        private static Cart _cart=new Cart();

        public HomeController(ILogger<HomeController> logger, FirstProjectContext firstProjectContext)
        {
            _logger = logger;
            _firstProjectContext = firstProjectContext;
        }

        public IActionResult Index()
        {
            var Products = _firstProjectContext.Products.ToList();
            return View(Products);
        }

        public IActionResult Detail(int id)
        {
            var Product = _firstProjectContext.Products
                .Include(p=>p.Item)
                .SingleOrDefault(x=>x.Id==id);
            if (Product == null)
            {
                return NotFound();
            }

            var Categories = _firstProjectContext.Products
                .Where(x => x.Id == id)
                .SelectMany(c => c.CategoryToProducts)
                .Select(ca => ca.Category)
                .ToList();

            DetailModeview detailModeview = new DetailModeview()
            {
                Product = Product,
                Categories = Categories
            };

            return View(detailModeview);
        }

        public IActionResult AddToCart(int Id)
        {
            
            var Product = _firstProjectContext
                .Products
                .Include(P => P.Item)
                .SingleOrDefault(x => x.ItemId == Id);

            if (Product!=null)
            {
                var CartItem = new CartItem()
                {
                    Item = Product.Item,
                    Quantity = 1
                };
                _cart.add(CartItem);
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            var CartVModel=new CartViewModel()
            {
                CartItems = _cart.CartItems,
                OrderTotal = _cart.CartItems.Sum(x=>x.GetTotalPrice())
            };

            List<CartItem> c = new List<CartItem>();
            c = CartVModel.Sorting();
            ViewBag.Price=CartVModel.OrderTotal;
            return View(c);
        }

        public IActionResult RemoveCart(int Id)
        {
            _cart.Remove(Id);
            return RedirectToAction("ShowCart");
        }




        [HttpGet("Contactus")]
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}