namespace Shop.DAL
{
    using System;
    using Models;
    using Data;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductRepository : IProductRepository, IDisposable
    {
        private ShopContext _context;

        public ProductRepository()
        {
            _context = new ShopContext();
        }

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        // Add query methods with their logic here

        //public Type GetContextType()
        //{
        //    return ShopContext;
        //}

        public IList<Product> GetProducts()
        {
            return _context.Products.ToList();
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
