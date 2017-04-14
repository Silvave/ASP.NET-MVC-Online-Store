namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            CreatedOn = DateTime.Now;
            Likes = new HashSet<CommentLike>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? EditedOn { get; set; }

        public bool Deleted { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<CommentLike> Likes { get; set; }
    }
}
