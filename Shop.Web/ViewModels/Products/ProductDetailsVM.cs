namespace Shop.Web.ViewModels.Products
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductDetailsVM
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 50)]
        public string Description { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Edited on")]
        public DateTime? ModifiedOn { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", ConvertEmptyStringToNull = true)]
        public decimal Price { get; set; }

        public string ProductImage { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [Display(Name = "Creator")]
        public virtual ApplicationUser Owner { get; set; }
    }
}