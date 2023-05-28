using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
 public class OrderData
    { 
       // public int _ShoppingBasketId { get; set; }
        //public int totalPrice { get; set; }
        public string address { get; set; }
       // public DateTime time { get; set; }
        public string phone { get; set; }
    }   
    public class Order
    {
        public int id { get; set; }
        public int _ShoppingBasketId { get; set; }
        public ShoppingBasket Basket { get; set; }
        public int totalPrice { get; set; }
        public string address { get; set; }
        public DateTime time { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }
}
