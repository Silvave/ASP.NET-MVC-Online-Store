using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data;
using Shop.Models;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopContext dbContext = new ShopContext();
            //dbContext.Database.Initialize(true);

            User user = new User() { FirstName = "Test", LastName = "Test", UserName = "test" };
            //dbContext.Users.Add(user);
            //dbContext.SaveChanges();
            Console.WriteLine(dbContext.Users.First().UserName);
        }
    }
}
