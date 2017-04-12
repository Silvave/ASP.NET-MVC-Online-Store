﻿namespace Shop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
