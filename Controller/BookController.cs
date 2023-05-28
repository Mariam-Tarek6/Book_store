using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using WebApplication4.Model;
namespace WebApplication4.Controller
{
    [ApiController]
    [Route("BOOK")]
    public class BookController:ControllerBase
    {
        BookStoreDB _context;
        IMapper _mapper;
        public BookController(BookStoreDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("Add_Book")]
        public ActionResult AddBook( BookView book)
        {
            var z = _context.authors.Where(c => c.id == book.authorId).FirstOrDefault();
            var z1 = _context.categories.Where(c => c.id == book.categoryId).FirstOrDefault();
            if (z == null || z1 == null)
            {
                return BadRequest(0);
            }
            var b = _mapper.Map<Book>(book);
            _context.books.Add(b);
            _context.SaveChanges();
            return Ok(1);
        }

        [HttpDelete("Delete_Book")]
        public ActionResult deleteBook( int id)
        {
            var c = _context.books.Where(c => c.id == id).FirstOrDefault();
            if (c == null)
            {
                return BadRequest(0);
            }
            
            _context.books.Remove(c);
            _context.SaveChanges();
            var x = _context.shoppingBasket_Books.Where(z => z.bookId == id).FirstOrDefault();
            if (x != null)
            {
                _context.shoppingBasket_Books.Remove(x);
                _context.SaveChanges();
            }
            return Ok(1);
        }
        [HttpPut("update_Data")]
        public ActionResult update ( int id, [FromForm] BookDtO book)   
        {
            var c = _context.books.AsNoTracking().Where(x=>x.id==id).FirstOrDefault();
            if (c == null)
            {
                return NotFound(0);
            }
            Book book1 = new Book()
            {
                id = id,
                title = book.title ?? c.title,
                price=book.price ?? c.price,
                qty=book.qty ?? c.qty,
                bookImage=book.bookImage ?? c.bookImage,
                category=c.category,
                categoryId=c.categoryId,
                author=c.author,
                authorId=c.authorId,
                date=c.date,
                details=c.details,
                shoppingBasket_Books=c.shoppingBasket_Books,
                comments=c.comments
            };
            _context.books.Update(book1);
            _context.SaveChanges();
            return Ok(1);
        }
        [HttpGet("Get_Book")]
        public ActionResult getBook(int id)
        {
            var book = _context.books.Where(s => s.id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound(0);
            }
            return Ok(book);
        }

        [HttpGet("getAll_Book")]
        public ActionResult getBooks()
        {
            List<Book> books2 = new List<Book>();
            List<Book> books = new List<Book>();
            books = _context.books.AsNoTracking().Include(c => c.author).ToList();
            foreach(var item in books)
            {
                if(item.qty > 0)
                {
                    books2.Add(item);
                }
            }
            return Ok(books2);

        }
        [HttpGet("OrderBookByDate")]
        public ActionResult OrderByDate()
        {
            List<Book> books2 = new List<Book>();
            List<Book> books = new List<Book>();
            books = _context.books.AsNoTracking().Include(c => c.author).ToList();
            foreach (var item in books)
            {
                if (item.qty > 0)
                {
                    books2.Add(item);
                }
            }
            var booksByDate = from a in books2
                    orderby a.date descending
                    select a;
            return Ok(booksByDate);
        }
        [HttpGet("OrderByPriceDescending")]
        public ActionResult OrderByPriceDescending()
        {
            List<Book> books2 = new List<Book>();
            List<Book> books = new List<Book>();
            books = _context.books.AsNoTracking().Include(c => c.author).ToList();
            foreach (var item in books)
            {
                if (item.qty > 0)
                {
                    books2.Add(item);
                }
            }
            var booksByPrice = from a in books2
                               orderby a.price descending
                               select a;
            return Ok(booksByPrice);

        }

        [HttpGet(" OrderByPriceAscending")]
        public ActionResult OrderByPriceAscending()
        {
            List<Book> books2 = new List<Book>();
            List<Book> books = new List<Book>();
            books = _context.books.AsNoTracking().Include(c => c.author).ToList();
            foreach (var item in books)
            {
                if (item.qty > 0)
                {
                    books2.Add(item);
                }
            }
            var booksByPrice = from a in books2
                               orderby a.price ascending
                               select a;
            return Ok(booksByPrice);

        }
        [HttpGet("top10Book")]
       // [EnableCors("AllowOrigin")]
        public ActionResult top10Book()
        {
            // var x = _context.books.AsNoTracking().OrderByDescending(c => c.date).ToList();
            var z = from a in _context.books.AsNoTracking()
                    orderby a.date descending
                    select a;
            var x = z.Take(10).ToList();
            return Ok(x);
        }
        /*
          // var x = _context.books.AsNoTracking().OrderByDescending(c => c.date).ToList();
            var z = from a in _context.books.AsNoTracking()
                    orderby a.date descending
                    select a;
            var x = z.Take(10).ToList();
            List<Tuple<string, List<Book>>> lst = new List<Tuple<string, List<Book>>>();
            lst.Add(new Tuple<string, List<Book>>("lst", x));
            return Ok(x);
         */
    }
}