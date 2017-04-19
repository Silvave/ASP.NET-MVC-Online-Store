using AutoMapper;
using Shop.DAL;
using Shop.Models;
using Shop.Web.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class CartController : Controller
    {
        private UserRepository userRepository;
        private ProductRepository productRepository;
        public CartController()
        {
            userRepository = new UserRepository();
            productRepository = new ProductRepository();
        }
        // GET: Cart
        public ActionResult Index(int? id)
        {
            string userId = userRepository.GetUserByName(User.Identity.Name).Id;
            if (id != null)
            {
                productRepository.AddProductToCart(id, userId);
            }
            IEnumerable<Product> userProducts = productRepository.GetUserCart(userId);
            decimal totalPrice = userProducts.Sum(x => x.Price);
            ViewBag.TotalPrice = totalPrice;
            return View(userProducts);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            productRepository.RemoveProductFromCart(id);
            return RedirectToAction("Index", "Cart");
        }
    }
}