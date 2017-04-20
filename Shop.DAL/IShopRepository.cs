namespace Shop.DAL
{
    using System;
    using Models;
    using System.Collections.Generic;

    public interface IShopRepository : IDisposable
    {
        // Add reference to the query methods here

        IList<Product> GetProducts();

        IList<ApplicationUser> GetAllUsers();

        IList<Product> GetAllProducts();

        IList<Product> GetTop3Products();

        IList<Category> GetCategories();

        Product GetProductById(int id);

        ApplicationUser GetUserById(string id);

        ApplicationUser GetUserByName(string name);

        void CreateProduct(Product product, string username);

        void EditProduct(Product editedProduct);

        void DeleteProduct(int id);

        void AddProductToCart(int? productId, string ownerId);

        void RemoveProductFromCart(int productId);

        IList<Product> GetUserCart(string userId);
    }
}
