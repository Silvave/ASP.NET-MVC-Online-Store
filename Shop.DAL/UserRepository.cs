using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL
{
    public class UserRepository
    {
        private ShopContext _context;

        public UserRepository()
        {
            _context = new ShopContext();
        }

        public ApplicationUser GetUserByName(string name)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName == name).FirstOrDefault();
            _context.Dispose();
            return user;
        }
    }
}
