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
    [Route(" Shopping_Basket")]
    public class ShoppingBasketController : ControllerBase
    {
        BookStoreDB _context;
        IMapper _mapper;
        public ShoppingBasketController(BookStoreDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public ActionResult add([FromForm] int bid, [FromForm] int cid, [FromForm] int q)
        {
            var a = _context.shoppingBaskets.Where(c => c.clientId == cid).FirstOrDefault();
            if (a == null) { return BadRequest(-1); }
            var x = a.id;
            ShoppingBasket_Book xx = new ShoppingBasket_Book() { Iqty = q,bookId=bid,ShoppingBasketID=x };
            _context.shoppingBasket_Books.Add(xx);
            _context.SaveChanges();
            var s = _context.books.Where(c => c.id == bid).FirstOrDefault();//exception
            if (s.qty - q >= 0)
            {
                s.qty = s.qty - q;
            }
            else
            {
                return BadRequest( s.qty);
            }
            if (s == null) { return BadRequest(-1); }
            a.qty = xx.Iqty + a.qty;
            a.totalPrice = (int)(a.totalPrice + s.price * a.qty);
            _context.shoppingBaskets.Update(a);
            _context.SaveChanges();
            return Ok(xx);
        }
        [HttpGet("getall")]
        public ActionResult action()
        {
            var x = _context.clients.AsNoTracking().Include(c => c.shopping).ThenInclude(c => c.BookList).ThenInclude(c => c.book).ToList();
            return Ok(x);
        }
        [HttpGet("get_Client")]
        public ActionResult result( int id)
        {
            var z = _context.clients.Where(c => c.id == id).FirstOrDefault();
            var x = _context.clients.AsNoTracking().Include(c => c.shopping).ThenInclude(c=>c.BookList).ThenInclude(c=>c.book).Where(c => c.id == id).ToList();
            //var x = _context.clients.Include(c => c.shopping).Where(c => c.id == id).FirstOrDefault();
            return Ok(x);
        }
        [HttpPut("update_Qty")]
        public ActionResult Qty([FromForm] int id , [FromForm] int bookid, [FromForm] int qty) {

            var x = _context.shoppingBaskets.Where(c => c.clientId == id).FirstOrDefault();
            var z = _context.shoppingBasket_Books.Where(c => c.ShoppingBasketID == x.id).Where(c=>c.bookId==bookid).FirstOrDefault();
            var a=_context.books.Where(c => c.id == bookid).FirstOrDefault();
            x.totalPrice = (int)(qty * a.price + x.totalPrice-(z.Iqty*a.price));
            x.qty =qty+ x.qty-z.Iqty;
            z.Iqty = qty;
            _context.shoppingBasket_Books.Update(z);
            _context.shoppingBaskets.Update(x);
            _context.SaveChanges();
            return Ok(z);
        }
        [HttpPut ("DeleteBookFromBasket")]
        public ActionResult DeleteBookFromBasket(int id , int bookid) 
        {
            var x = _context.shoppingBaskets.Where(c => c.clientId == id).FirstOrDefault();
            var z = _context.shoppingBasket_Books.Where(c => c.ShoppingBasketID == x.id).Where(c => c.bookId == bookid).FirstOrDefault();
            var a = _context.books.Where(c => c.id == bookid).FirstOrDefault();
            x.qty = x.qty - z.Iqty;
            x.totalPrice = (int)(x.totalPrice - (z.Iqty * a.price));
            _context.shoppingBasket_Books.Remove(z);
            _context.SaveChanges();
            return Ok(1);
        }
    }
}