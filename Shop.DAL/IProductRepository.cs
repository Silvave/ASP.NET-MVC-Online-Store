namespace Shop.DAL
{
    using System;
    using Models;
    using System.Collections.Generic;

    public interface IProductRepository : IDisposable
    {
        // Add reference to the query methods here

        //Type GetContextType();

        IList<Product> GetProducts();

    }
}
