namespace Shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductLike
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Username { get; set; }

        public bool LikeIt { get; set; }

        public bool DislikeIt { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
