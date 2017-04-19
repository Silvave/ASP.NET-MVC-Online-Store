namespace Shop.DAL
{
    using System;
    using Models;
    using System.Collections.Generic;

    public interface IProductRepository : IDisposable
    {
        // Add reference to the query methods here

        IList<Product> GetProducts();

        IList<ApplicationUser> GetAllUsers();

        IList<Product> GetAllProducts();

        IList<Category> GetCategories();

        Product GetProductById(int id);

        ApplicationUser GetUserById(string id);

        void CreateProduct(Product product, string username);

        void EditProduct(Product editedProduct);

        void DeleteProduct(int id);
        
    }
}
