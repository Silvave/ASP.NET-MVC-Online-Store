using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Location { get; set; }

        public virtual ICollection<User> Residents { get; set; }
    }
}
