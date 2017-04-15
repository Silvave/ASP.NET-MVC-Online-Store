namespace Shop.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Models;
    using System.Web;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 1)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Profile picture")]
        public HttpPostedFileBase ProfilePicture { get; set; }
    }
}