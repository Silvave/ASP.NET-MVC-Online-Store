using Shop.Models;
using Shop.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.DAL;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
        }

        //Get: /Product/Create
        public ActionResult Create()
        {
            IEnumerable<Category> categories = ShopRepository.GetCategories();
            ViewBag.Categories = categories;
            return View();
        }

        //Post: /Product/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            Console.WriteLine(product);
            return View(product);
        }

    }
}