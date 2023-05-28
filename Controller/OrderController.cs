using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Model;
namespace WebApplication4.Controller
{
    [ApiController]
    [Route(" Order")]
    public class OrderController : ControllerBase
    {
        BookStoreDB _context;
        IMapper _mapper;
        public OrderController(BookStoreDB context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      [HttpPost("Order")]
          public ActionResult order([FromForm] int id, [FromForm] OrderData order)
        {
            var x = _context.clients.Where(c => c.id == id).FirstOrDefault();
            var e = x.email;
            var p = x.password;
            var n = x.name;
            Order order1 = new Order()
            {
                address = order.address,
                email = e,
                password =p,
                name =p,
                phone = order.phone,
                time = DateTime.Now ,
                _ShoppingBasketId= (int)x.ShoppingBasketid,
                 totalPrice = _context.shoppingBaskets.Where(c => c.clientId == id).Select(c => c.totalPrice).FirstOrDefault()

        };
           // order1.totalPrice = _context.shoppingBaskets.Where(c => c.clientId == id).Select(c => c.totalPrice).FirstOrDefault();
          //  return Ok(order1);
             var nn = _context.shoppingBasket_Books.Where(z => z.ShoppingBasketID == id).ToList();
            foreach(var item in nn)
            {
                _context.shoppingBasket_Books.Remove(item);
                _context.SaveChanges();
            }
            var q=_context.shoppingBaskets.Where(c => c.clientId == id).FirstOrDefault();
            q.totalPrice = 0;
            q.qty = 0;
            return Ok(order1);
        }
    }
}