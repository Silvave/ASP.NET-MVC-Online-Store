namespace Shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 4)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}
