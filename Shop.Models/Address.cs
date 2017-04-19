namespace Shop.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 5)]
        public string StreetName { get; set; }

        public int TownId { get; set; }

        public string UserId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }
    }
}
