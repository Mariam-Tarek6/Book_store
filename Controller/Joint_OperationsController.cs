using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Model;

namespace WebApplication4.Controller
{
    [ApiController]
    [Route("Joint_Operations")]
    public class Joint_OperationsController : ControllerBase
    {
        BookStoreDB _context;
        
        public Joint_OperationsController(BookStoreDB context)
        {
            _context = context;
         
        }
        [HttpGet("Search")]
        public ActionResult Searche(string name)
        {
           
          
            var v = from a in _context.authors
                    where a.name.Contains(name)
                    select a;
            var v2 = from z in _context.books
                     where z.title.Contains(name)
                     select z;
            List<object> o = new List<object>();
            foreach(var item in v)
            {
                o.Add(item);
            }
            foreach (var item in v2)
            {
                o.Add(item);
            }
            if (v == null && v2==null)
            {
                return NotFound(0);

            }
            
            return Ok(o);
        }
        [HttpPost("Add_image")]
        public ActionResult addBook(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filepath = fullPath + "/" + name;

            var stream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(stream);

            return Ok("Images/" +name);
        }
    }
        
}
