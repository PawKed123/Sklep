using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracaDyplomowa.Data;
using PracaDyplomowa.Models;
using PracaDyplomowa.Session;

namespace PracaDyplomowa.Controllers
{

    public class OrderController : Controller
    {
        private ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Orders.ToList());
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order Order)
        {
            List<Products> productList = HttpContext.Session.Get<List<Products>>("products");

            foreach (var product in productList)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.ProductId = product.Id;
                Order.OrderDetails.Add(orderDetails);
            }


            _db.Orders.Add(Order);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Products>());

            return RedirectToAction(nameof(Confirmation));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var order = _db.Orders.First(x => x.Id == id);

            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Confirmation()
        {
            return View();
        }

    }
}
