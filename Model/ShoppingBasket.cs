using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication4.Model
{
    public class ShoppingBasket
    {
        public int id { get; set; }
        public int totalPrice { get; set; }
        public int qty { get; set; }
        public DateTime date { get; set; }
        public int? clientId { get; set; }
        [ForeignKey("clientId")]
        public Client? client { get; set; }
        public ICollection<ShoppingBasket_Book> BookList { get; set; }
    }
}
