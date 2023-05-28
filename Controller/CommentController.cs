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
    [Route("Comment")]
    public class CommentController : ControllerBase
    {

        BookStoreDB _context;
        //IMapper _mapper;

        public CommentController(BookStoreDB context)
        {
            _context = context;
            
        }
        [HttpPost("AddComment")]
        public ActionResult addComment(int ClientID, int BookID, string comment)
        {
            var x = _context.clients.Where(c => c.id == ClientID).FirstOrDefault();
            var x1 = _context.books.Where(c1 => c1.id == BookID).FirstOrDefault();
            if (x == null || x1 == null )
            {
                return NotFound(0);
            }
            Comment c = new Comment()
            {
                 comment=comment,
                 bookId=BookID,
                 clientid= ClientID,
                 Book = x1,
                client = x
            };
            _context.comments.Add(c);
            _context.SaveChanges();
            return Ok(c);
            
        }

    }
}
