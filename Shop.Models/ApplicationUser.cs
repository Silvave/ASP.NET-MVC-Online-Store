namespace Shop.Models
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using System.ComponentModel.DataAnnotations;
    using System.Collections;
    using System.Collections.Generic;

    public enum Gender
    {
        male,
        female,
        alien
    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 2)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        public byte[] ProfilePicture { get; set; }

        public bool IsDeleted { get; set; }
    }
}
