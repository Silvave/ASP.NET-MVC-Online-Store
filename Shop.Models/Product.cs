namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
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
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 50)]
        public string Description { get; set; }

        private DateTime createdOn;

        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public byte[] ProductImage { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductLike> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = DateTime.Now; }
        }
    }
}
