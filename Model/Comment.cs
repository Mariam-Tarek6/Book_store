using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    public class Comment
    {
        public int id { get; set; }
        public string comment { get; set; }
        public int? bookId { get; set; }
        [ForeignKey("bookId")]
        public Book? Book { get; set; }
        public  int? clientid { get; set; }
        [ForeignKey("clientid")]
        public Client? client { get; set; }
    }
}
