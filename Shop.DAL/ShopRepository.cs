namespace Shop.DAL
{
    using System;
    using Data;

    public class ShopRepository : IShopRepository, IDisposable
    {
        private ShopContext _context;

        public ShopRepository(ShopContext context)
        {
            _context = context;
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
