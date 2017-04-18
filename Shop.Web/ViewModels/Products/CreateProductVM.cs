namespace Shop.Web.ViewModels.Products
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class CreateProductVM
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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", ConvertEmptyStringToNull = true)]
        public decimal Price { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Product Image")]
        public HttpPostedFileBase ProductImage { get; set; }

        public virtual IList<Category> Categories { get; set; }
        public virtual IList<ProductLike> Likes { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
}