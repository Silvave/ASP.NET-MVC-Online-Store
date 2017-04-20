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
        private IShopRepository _shopRepository;

        public CartController()
        {
            _shopRepository = new ShopRepository();
        }
        // GET: Cart
        public ActionResult Index(int? id)
        {
            string userId = _shopRepository.GetUserByName(User.Identity.Name).Id;
            if (id != null)
            {
                _shopRepository.AddProductToCart(id, userId);
            }
            IList<Product> userProducts = _shopRepository.GetUserCart(userId);
            decimal totalPrice = userProducts.Sum(x => x.Price);
            ViewBag.TotalPrice = totalPrice;
            return View(userProducts);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            _shopRepository.RemoveProductFromCart(id);
            return RedirectToAction("Index", "Cart");
        }
    }
}