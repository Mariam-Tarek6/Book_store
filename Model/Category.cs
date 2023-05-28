using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    [Keyless]
    public class CategoryAdd {
        public string? name { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string? name { get; set; }
        public ICollection <Book> Books { get; set; }
    }

}
