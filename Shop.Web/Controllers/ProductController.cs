namespace Shop.Web.Controllers
{
    using AutoMapper;
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels.Products;

    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        // GET: Product
        public ActionResult Index()
        {
            Products();
            return View();
        }

        [ChildActionOnly]
        public ActionResult Products()
        {
            List<ListProductsVM> productList = new List<ListProductsVM>();

            var products = _productRepository.GetProducts();
            foreach (var product in products)
            {
                productList.Add(Mapper.Instance.Map<ListProductsVM>(product));
            }

            return PartialView("Products", productList);
        }

        //Get: /Product/Create
        public ActionResult Create()
        {
            CreateProductVM createProduct = new CreateProductVM();
            createProduct.Categories = _productRepository.GetCategories();

            return View("Create", createProduct);
        }

        //Post: /Product/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductVM model)
        {
            var product = Mapper.Instance.Map<Product>(model);

            string currentUsername = User.Identity.Name;

            _productRepository.CreateProduct(product, currentUsername);

            return RedirectToAction("Index", "Product");
        }

        // GET: Product/Details/1
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Shared");
            }

            var product = _productRepository.GetProductById((int)id);

            var productDetailsVM = Mapper.Instance.Map<ProductDetailsVM>(product);

            return View("Details", productDetailsVM);
        }

        // GET: Product/Edit/1
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Shared");
            }
            var product = _productRepository.GetProductById((int)id);

            var productDetailsVM = Mapper.Instance.Map<ProductDetailsVM>(product);

            return View("Edit", productDetailsVM);
        }

        // POST: Product/Edit/1
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDetailsVM productDetails)
        {
            var productToEdit = Mapper.Instance.Map<Product>(productDetails);

            productToEdit.ModifiedOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                _productRepository.EditProduct(productToEdit);

                return RedirectToAction("Index", "Product");
            }

            return RedirectToAction("Error", "Shared");
        }

        // GET: Product/Delete/1
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Shared");
            }
            var product = _productRepository.GetProductById((int)id);

            var productDetailsVM = Mapper.Instance.Map<ProductDetailsVM>(product);

            return View("Delete", productDetailsVM);
        }

        // POST: Delete/Product/1
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductDetailsVM productVMToDel)
        {
            _productRepository.DeleteProduct(productVMToDel.Id);

            return RedirectToAction("Index", "Product");
        }

        #region Helpers

        public IList<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void CreateProduct(Product product, string username)
        {
            _productRepository.CreateProduct(product, username);
        }

        public IList<Category> GetCategories()
        {
            return _productRepository.GetCategories();
        }

        #endregion
    }
}