namespace Shop.DAL
{
    using System;
    using Models;
    using Data;
    using System.Collections.Generic;

    public class ShopRepository : IShopRepository, IDisposable
    {
        private ShopContext _context;

        public ShopRepository(ShopContext context)
        {
            _context = context;
        }

        // Add query methods with their logic here
        public static bool CreateProduct(Product product)
        {
            bool isSuccess = false;
            using (ShopRepository repo = new ShopRepository(new ShopContext()))
            {
                IEnumerable<Product> products = repo._context.Products;

            }
            return isSuccess;
        }

        public static IEnumerable<Category> GetCategories()
        {
            using (ShopRepository repo = new ShopRepository(new ShopContext()))
            {
                IEnumerable<Category> categories = repo._context.Categories;
                return categories;
            }
        }

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
    }
}
