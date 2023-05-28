using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication4.Model
{
    public class ShoppingBasket_Book
    {
        public int id { get; set; }
        public int Iqty { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int ShoppingBasketID { get; set; }
         [ForeignKey("ShoppingBasketID")]
        public ShoppingBasket shoppingBasket { get; set; }
        //public int eventId { get; set; }
        //public Event Event { get; set; }
    }
}
