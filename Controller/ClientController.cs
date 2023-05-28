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
    [Route("Client")]
    public class ClientController:ControllerBase
    {
        BookStoreDB _context;
        IMapper _mapper;
        public ClientController(BookStoreDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("Add_Client")]
        public ActionResult addClient( ClientRegister client)
        {
            Client c = _mapper.Map<Client>(client);
            if (client.email.StartsWith("Admin#."))
            {
                c.isAdmin = true;
            }
            else
            {
                c.isAdmin = false;
            }
            ShoppingBasket x = new ShoppingBasket();
            _context.clients.Add(c);
            _context.SaveChanges();
            x.qty = 0;
            x.clientId = c.id;
            x.totalPrice = 0;
           
            _context.shoppingBaskets.Add(x);
            _context.SaveChanges();
            var a = _context.clients.Where(q => q.id == x.clientId).FirstOrDefault();
            a.ShoppingBasketid = x.id;
            _context.clients.Update(a);
            _context.SaveChanges();
            return Ok(1);
        }
        [HttpPost ("Client_Login")]
        public ActionResult login( ClientLogin client)
        {
            
            var x = _context.clients.Where(c => c.email == client.email && c.password == client.password).FirstOrDefault();
            if (x == null)
            {
                return NotFound(0);
            }
            
            return Ok(x);
        }
        [HttpPut("update_Client")]
        public ActionResult update( int id,  ClientRegister clientRegister)
        {
            var c = _context.clients.AsNoTracking().Where(x=>x.id==id).FirstOrDefault();
            if (c == null)
            {
                return NotFound(0);
            }
            Client client = new Client()
            {
                id = c.id,
                name = clientRegister.name ?? c.name,
                email = clientRegister.email ?? c.email,
                password = clientRegister.password ?? c.password,
               
                shopping=c.shopping,
                ShoppingBasketid=c.ShoppingBasketid
            };
            _context.clients.Update(client);
            _context.SaveChanges();
            return Ok(client);
        }
        [HttpDelete("Delete_client")]
        public ActionResult DeleteClient(int id)
        {
            var a = _context.clients.Where(x => x.id == id).FirstOrDefault();
            if (a == null )
            {
                return NotFound(0);
            }

            var t = _context.shoppingBaskets.Where(x => x.clientId ==id ).FirstOrDefault();
            _context.clients.Remove(a);
            _context.SaveChanges();
            _context.shoppingBaskets.Remove(t);
            _context.SaveChanges();
            return Ok(1);
        }
        [HttpGet("get_AllClient")]
        public ActionResult get_AllClient()
        {
            var x = _context.clients.AsNoTracking().Include(c => c.shopping).ThenInclude(c => c.BookList).ThenInclude(c => c.book).ToList();
            return Ok(x);
        }
    }
}