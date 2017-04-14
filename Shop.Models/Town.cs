namespace Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 4)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
