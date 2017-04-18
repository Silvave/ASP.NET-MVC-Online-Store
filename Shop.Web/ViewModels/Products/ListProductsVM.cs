namespace Shop.Web.ViewModels.Products
{
    using Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;

    public class ListProductsVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 2)]
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

        public Image ProductImage { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}