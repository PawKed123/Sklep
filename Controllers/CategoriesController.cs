using PracaDyplomowa.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PracaDyplomowa.Controllers
{

    public class CategoriesController : Controller
    {
        private ApplicationDbContext _db;
        public CategoriesController(ApplicationDbContext db)
        {

            _db = db;

        }
        public ActionResult Komputer()
        {
            return View(_db.Products.ToList());

        }

        public ActionResult Laptop()
        {
            return View(_db.Products.ToList());

        }
        public ActionResult Podzespoly()
        {
            return View(_db.Products.ToList());

        }
        public ActionResult Monitor()
        {
            return View(_db.Products.ToList());

        }

    }
}
