using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels.Account
{
    public class ProfilePageViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}