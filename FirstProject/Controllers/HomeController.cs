using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using FirstProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirstProjectContext _firstProjectContext;

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
        [Authorize]
        public IActionResult AddToCart(int Id)
        {
            
            var Product = _firstProjectContext
                .Products
                .Include(P => P.Item)
                .SingleOrDefault(x => x.ItemId == Id);

            if (Product!=null)
            {
                int Userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var Order = _firstProjectContext
                    .order.FirstOrDefault(o => o.Userid == Userid && o.IsFinally == false);

                if (Order != null)
                {
                    var orderdetail = _firstProjectContext
                        .OrderDetails.FirstOrDefault(o => o.Productid == Product.Id &&o.Orderid==Order.Orderid);

                    if (orderdetail!=null)
                    {
                        orderdetail.Count += 1;
                    }
                    else
                    {
                        _firstProjectContext.OrderDetails.Add(new OrderDetail()
                        {
                            Orderid = Order.Orderid,
                            Productid = Product.Id,
                            Count = 1,
                            Price = Product.Item.Price
                        });

                    }
                    
                }
                else
                {
                    Order = new Order()
                    {
                        IsFinally = false,
                        CreateDate = DateTime.Now,
                        Userid = Userid
                    };
                    _firstProjectContext.order.Add(Order);
                    _firstProjectContext.SaveChanges();
                    _firstProjectContext.OrderDetails.Add(new OrderDetail()
                    {
                        Orderid = Order.Orderid,
                        Productid = Product.Id,
                        Count = 1,
                        Price = Product.Item.Price
                    });

                }
                _firstProjectContext.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }
        [Authorize]
        public IActionResult ShowCart()
        {
            //var CartVModel=new CartViewModel()
            //{
            //    CartItems = _cart.CartItems,
            //    OrderTotal = _cart.CartItems.Sum(x=>x.GetTotalPrice())
            //};

            //List<CartItem> c = new List<CartItem>();
            //c = CartVModel.Sorting();
            //ViewBag.Price=CartVModel.OrderTotal;
            int Userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _firstProjectContext
                .order.Where(x => x.IsFinally == false && x.Userid == Userid)
                .Include(i => i.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();

            return View(order);
        }

        public IActionResult RemoveCart(int detailId)
        {
            var orderDetail = _firstProjectContext.OrderDetails.Find(detailId);
            if (orderDetail.Count > 1)
            {
                orderDetail.Count-=1;
            }
            else
            {
                _firstProjectContext.Remove(orderDetail);
            }
            _firstProjectContext.SaveChanges();
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