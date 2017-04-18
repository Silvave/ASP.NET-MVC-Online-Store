namespace Shop.Web.Controllers
{
    using AutoMapper;
    using DAL;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
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
                //productList.Add(new ListProductsVM()
                //{
                //    Title = product.Title,
                //    ShortDescription = product.ShortDescription,
                //    Description = product.Description,
                //    CreatedOn = product.CreatedOn,
                //    ModifiedOn = product.ModifiedOn,
                //    Price = product.Price,
                //    Owner = product.Owner
                //});
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

        //Get: /Product/Details
        [HttpGet]
        public ActionResult Details(string id)
        {
            int productId = -1;
            if (id != null)
            {
                productId = int.Parse(id);
            }
            else
            {
                return RedirectToAction("Error", "Shared");
            }
            Product product = _productRepository.Details(productId);
            IEnumerable<Category> categories = product.Categories.ToList();
            ProductDetailsVM targetProduct = new ProductDetailsVM()
            {
                Title = product.Title,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                CreatedOn = product.CreatedOn,
                ModifiedOn = product.ModifiedOn,
                Price = product.Price,
                ProductImage = product.ProductImage,
                Categories = categories
            };
            //ProductDetailsVM targetProduct = Mapper.Instance.Map<ProductDetailsVM>(product);

            return View(targetProduct);
        }

        //[HttpPost]
        //public ActionResult Details()
        //{
        //    return RedirectToAction("Details", "Product");
        //}

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