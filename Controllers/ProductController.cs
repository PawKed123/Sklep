using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracaDyplomowa.Data;
using PracaDyplomowa.Models;
using Microsoft.AspNetCore.Authorization;

namespace PracaDyplomowa.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private IWebHostEnvironment _he;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

     
        public IActionResult Create()
        {                  
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(Products product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _db.Products.FirstOrDefault(x => x.Name == product.Name);
                if (searchProduct != null)
                {
                    ViewBag.message = "Produkt o takiej nazwie już istnieje";
                                 
                    return View(product);
                }

                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    product.Image = "Images/brak.JPG";
                }
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

       

        public ActionResult Edit(int id)
        {                
            
            var product = _db.Products.First(x => x.Id == id);          
            return View(product);
        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));                
                    products.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    products.Image = "Images/brak.JPG";
                }
                _db.Products.Update(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

       
        public ActionResult Details(int id)
        {
            
            var product = _db.Products.First(x => x.Id == id);           
            return View(product);
        }

      
        public ActionResult Delete(int id)
        {
            
            var product = _db.Products.Where(x => x.Id == id).First();          
            return View(product);
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            
            var product = _db.Products.First(x => x.Id == id);
            
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
