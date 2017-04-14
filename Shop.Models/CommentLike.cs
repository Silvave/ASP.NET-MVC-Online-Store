namespace Shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CommentLike
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Username { get; set; }

        public bool LikeIt { get; set; }

        public bool DislikeIt { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}
