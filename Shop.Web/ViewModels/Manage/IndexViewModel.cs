namespace Shop.Web.ViewModels.Manage
{
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}