using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    public class ClientRegister
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public bool isAdmin { get; set; }
    }
    public class ClientLogin
    {
        public string? email { get; set; }
        public string? password { get; set; }
        public bool isAdmin { get; set; }
       
    }
    public class Client
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public bool isAdmin { get; set; }
        public int? ShoppingBasketid { get; set; }
        [ForeignKey("ShoppingBasketid")]
        public ShoppingBasket? shopping { get; set; }
        public  ICollection<Comment> comments { get; set; }
    }
}
