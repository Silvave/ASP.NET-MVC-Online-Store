namespace Shop.DAL
{
    using System;
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    public class ProductRepository : IProductRepository, IDisposable
    {
        private ShopContext _context;

        public ProductRepository()
        {
            _context = new ShopContext();
        }

        // Add query methods with their logic here

        public IList<Product> GetProducts()
        {
            return _context.Products.Where(p => p.Deleted == false).ToList();
        }
        public IList<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public Product GetProductById(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public ApplicationUser GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product, string username)
        {
            var productList = new List<Category>();
            foreach (Category cat in product.Categories.Where(c => c.Checked))
            {
                productList.Add(_context.Categories.FirstOrDefault(c => c.Id == cat.Id));
            }
            product.Categories = productList;

            //product.Owner = _context.Users.FirstOrDefault(u => u.UserName == username);

            _context.Products.Add(product);
            Save();
        }

        public IList<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void EditProduct(Product editedProduct)
        {
            var productToEdit = _context.Products.FirstOrDefault(p => p.Id == editedProduct.Id);
            productToEdit.Title = editedProduct.Title;
            productToEdit.ShortDescription = editedProduct.ShortDescription;
            productToEdit.Description = editedProduct.Description;
            productToEdit.Price = editedProduct.Price;
            productToEdit.ModifiedOn = editedProduct.ModifiedOn;

            Save();
        }

        public void AddProductToCart(int? productId, string ownerId)
        {
            UserCart cart = new UserCart();
            cart.OwnerId = ownerId;
            cart.ProductId = productId ?? -1;
            //_context.Entry(owner).State = System.Data.Entity.EntityState.Added;
            //_context.Entry(product).State = System.Data.Entity.EntityState.Added;
            _context.UsersCarts.Add(cart);
            _context.SaveChanges();
        }

        public void RemoveProductFromCart(int productId)
        {
            _context.UsersCarts.Remove(_context.UsersCarts.Where(x => x.ProductId == productId).First());
            Save();
        }

        public IEnumerable<Product> GetUserCart(string userId)
        {
            List<int> productIds = _context.UsersCarts.Where(uc => uc.OwnerId == userId).Select(x => x.ProductId).ToList();
            List<Product> result = new List<Product>();
            foreach (var productId in productIds)
            {
                Product currentProduct = _context.Products.Where(x => x.Id == productId).First();
                result.Add(currentProduct);
            }
            return result;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            product.Deleted = true;
            Save();
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }

        #region dispose
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
