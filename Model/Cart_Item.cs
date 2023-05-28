using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    public class Cart_Item
    {
        public int IId { get; set; }
        public int IQty { get; set; }
    }

    public class OrderDTO
    {
        public int customerId { get; set; }

        public List<Cart_Item> list { get; set; }
    }
    
}
