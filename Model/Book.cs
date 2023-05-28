using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    public class BookDtO
    {
        public string title { get; set; }
        public int? price { get; set; }
        public int? qty { get; set; }
        public string bookImage { get; set; }
    }
    public class BookView
    {
        
        public string title { get; set; }
        public DateTime date { get; set; }
        public int? price { get; set; }
        public int? qty { get; set; }
        public string bookImage { get; set; }
        public int authorId { get; set; }
        //public Author author { get; set; }
        public int categoryId { get; set; }
       // public Category category { get; set; }
        public string details { get; set; }
    
    }
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public int? price { get; set; }
        public int? qty { get; set; }
        public string details { get; set; }
        public string bookImage { get; set; }
        public int authorId { get; set; }
        [ForeignKey("authorId")]
        public Author author { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; }
        public ICollection <ShoppingBasket_Book> shoppingBasket_Books { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}