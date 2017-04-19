namespace Shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductLike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public bool LikeIt { get; set; }

        public bool DislikeIt { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
