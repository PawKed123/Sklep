using PracaDyplomowa.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PracaDyplomowa.Controllers
{

    public class CustomerController : Controller
    {

        UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _db;


        public CustomerController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {

            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            string username = _userManager.GetUserName(User);

            ViewData["username"] = username;

            return View();
        }

        public ActionResult AllProducts()
        {
            return View(_db.Products.ToList());

        }

    }
}
