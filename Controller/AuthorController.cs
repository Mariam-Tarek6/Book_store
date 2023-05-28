using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Model;
namespace WebApplication4.Controller
{
    [ApiController]
    [Route(" Author")]
    public class AuthorController :ControllerBase
    {
        BookStoreDB _context;
        IMapper _mapper;

        public AuthorController(BookStoreDB context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Add_Author")]
        public ActionResult addAuthor( AuthorAdd author)
        {
            Author aa = _mapper.Map<Author>(author);

            _context.authors.Add(aa);
             _context.authors.Add(aa);
            _context.SaveChanges();
            return Ok(aa);
        }
        [HttpDelete("Delete_ Author")]
        public ActionResult deleteAuthor( int id)
        {
            var c = _context.authors.Where(c => c.id == id).FirstOrDefault();
            if (c == null)
            {
                return BadRequest(0);
            }
            _context.authors.Remove(c);
            _context.SaveChanges();
            return Ok(1);
        }

        [HttpGet("Get_Author")]
        public ActionResult GetAuthor(int id )
        {
          
            var author = _context.authors.Where(s => s.id == id).FirstOrDefault();
            if (author == null)
            {
                return NotFound(0);
            }
            return Ok(author);
        }
        [HttpGet("getAll_Author")]
        public ActionResult get_Author()
        {
           // var x = _context.authors.AsNoTracking().Include(c => c.books).ThenInclude(c => c.shoppingBasket_Books).ToList();
            var xx = _context.authors.AsNoTracking().Include(c => c.books).ToList();
            return Ok(xx);
        }
        [HttpPut("update_Author")]
        public ActionResult update( int id, AuthorAdd author)
        {
            var c = _context.authors.AsNoTracking().Where(x => x.id == id).FirstOrDefault();
            if (c == null)
            {
                return NotFound(0);
            }
            Author Author1 = new Author()
            {
                id=id,
                name = author.name ?? c.name,
                authorImage=author.authorImage??c.authorImage,
                books=c.books
                
            };
            _context.authors.Update(Author1);
            _context.SaveChanges();
            return Ok(Author1);
        }
        [HttpGet("top10Author")]
        public ActionResult top10Author()
        {
            Dictionary<int, int> de = new Dictionary<int, int>();
            foreach (var item in _context.books)
            {
                if (de.ContainsKey(item.authorId))
                {
                    de[item.authorId]++;
                }
                else
                {
                    de.Add(item.authorId, 1);
                }

            }
            List<Author> topAuthors = new List<Author>();
            var sortedDict = from entry in de
                             orderby entry.Value descending
                             select entry;
            foreach (var item in sortedDict)
            {
                var c = _context.authors.Where(x => x.id == item.Key).Select(z => z).FirstOrDefault();
                topAuthors.Add(c);
            }
            var a = topAuthors.Take(10);
            return Ok(a);

        }
    }
}