using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
   
    public class AuthorAdd
    {
       
        public string? name { get; set; }
        public string? authorImage { get; set; }
    }
    public class Author
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? authorImage { get; set; }
        public ICollection <Book> books { get; set; }
       

    }
}
