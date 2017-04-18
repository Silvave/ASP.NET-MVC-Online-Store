namespace ConsoleClient
{
    using System;
    using Shop.Data;
    using Shop.Models;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            ShopContext context = new ShopContext();

            //var bira = new Product()
            //{
            //    Title = "Nakov's beer",
            //    ShortDescription = "Got it after lecture",
            //    Description = "Bla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lbaBla bla bla bla lba",
            //    Price = 1.23m,
            //    CreatedOn = DateTime.Now
            //};

            //bira.Owner = context.Users.FirstOrDefault();

            //context.Products.Add(bira);
            //context.SaveChanges();
            //context.Database.Initialize(true);

            //var country = new Country()
            //{
            //    Name = "Bulgaria"
            //};

            //context.Countries.Add(country);
            //context.SaveChanges();

            //var bg = context.Countries.Find(1);
            //Console.WriteLine(bg.Name);

            //var towns = new List<Town>()
            //{
            //    new Town() { Name = "Burgas" },
            //    new Town() { Name = "Sofia" },
            //    new Town() { Name = "Varna" }
            //};

            //var addresses = new List<Address>()
            //{
            //    new Address() { StreetName = "Borovo",  }
            //};

            //var addresses = context.Addresses.ToList();

            //Console.WriteLine("Addresses:");
            //addresses.ForEach(a => Console.WriteLine($"\t{a.Location}"));

            //var cat = context.Categories.Find(1);

            //Console.WriteLine($"Category: {cat.Name}");
            //Console.WriteLine($"Products:");
            //foreach (var product in cat.Products)
            //{
            //    Console.WriteLine($"\t{product.Name} - {product.Price}");
            //}
        }
    }
}
