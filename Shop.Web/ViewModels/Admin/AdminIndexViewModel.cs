using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels.Admin
{
    public class AdminIndexViewModel
    {
        public AdminIndexViewModel()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public string AdminName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}