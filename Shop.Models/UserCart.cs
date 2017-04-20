using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class UserCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string OwnerId { get; set; }
    }
}
