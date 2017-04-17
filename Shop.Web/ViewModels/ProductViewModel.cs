namespace Shop.Web.ViewModels
{
    using Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel
    {
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

        public decimal Price { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}