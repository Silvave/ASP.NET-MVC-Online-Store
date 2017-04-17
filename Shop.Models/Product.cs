﻿namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            CreatedOn = DateTime.Now;
            Categories = new HashSet<Category>();
            Likes = new HashSet<ProductLike>();
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", 
            MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        //[Required]
        //[StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 50)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", ConvertEmptyStringToNull = true)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductLike> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
