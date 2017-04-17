namespace Shop.Web.Controllers
{
    using DAL;
    using Models;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels;

    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        public static List<ProductViewModel> productList = new List<ProductViewModel>();

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
            productList.Clear();

            var products = _productRepository.GetProducts();
            foreach (var product in products)
            {
                productList.Add(new ProductViewModel()
                {
                    Title = product.Title,
                    ShortDescription = product.ShortDescription,
                    Description = product.Description,
                    CreatedOn = product.CreatedOn,
                    ModifiedOn = product.ModifiedOn,
                    Price = product.Price,
                    Owner = product.Owner
                });
            }

            return PartialView("Products");
        }

        #region Helpers

        public IList<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        #endregion
    }
}