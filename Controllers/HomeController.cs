using PracaDyplomowa.Data;
using PracaDyplomowa.Models;
using PracaDyplomowa.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace PracaDyplomowa.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }



        public async Task<IActionResult> Index()
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                List<string> userRoles = (await _userManager.GetRolesAsync(user)).ToList();

                if (userRoles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
            return View(_db.Products.ToList());
        }


        public ActionResult AllProducts()
        {
            return View(_db.Products.ToList());
        }


        public ActionResult Detail(int id)
        {

            var product = _db.Products.First(x => x.Id == id);

            return View(product);
        }


        [HttpPost]
        [ActionName("Detail")]
        public ActionResult AddToCart(int id)
        {
            var product = _db.Products.First(x => x.Id == id);
            List<Products> productList = HttpContext.Session.Get<List<Products>>("products");
            if (productList == null)
            {
                productList = new List<Products>();
            }
            productList.Add(product);
            HttpContext.Session.Set("products", productList);
            return RedirectToAction(nameof(Detail));
        }


        [ActionName("Remove")]
        public IActionResult RemoveFromCart(int id)
        {
            List<Products> productList = HttpContext.Session.Get<List<Products>>("products");
            var product = productList.First(x => x.Id == id);
            productList.Remove(product);
            HttpContext.Session.Set("products", productList);
            return RedirectToAction(nameof(Cart));
        }


        [HttpPost]
        public IActionResult Remove(int id)
        {
            List<Products> productList = HttpContext.Session.Get<List<Products>>("products");
            var product = productList.First(x => x.Id == id);
            productList.Remove(product);
            HttpContext.Session.Set("products", productList);
            return RedirectToAction(nameof(AllProducts));
        }


        [Authorize]
        public IActionResult Cart()
        {
            List<Products> productList = HttpContext.Session.Get<List<Products>>("products");
            if (productList == null)
            {
                productList = new List<Products>();
            }
            return View(productList);
        }


    }
}
