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
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        BookStoreDB _context;
        IMapper _mapper;
        public CategoryController(BookStoreDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("add_category")]
        public ActionResult addCat(CategoryAdd category)
        {
            var c = _mapper.Map<Category>(category);
            _context.categories.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }
        [HttpGet("getAll_Category")]
        public ActionResult getCategories()
        {
            var x = _context.categories.AsNoTracking().Include(c=>c.Books).ToList();
            return Ok(x);
        }
        [HttpGet("Get_Category")]
        public ActionResult GetCategory( int  id )
        {
            var x = _context.categories.Where(c=>c.id==id);
            if (x == null)
            {
                return NotFound(0);
            }
            //var v = x.Join( _context.books,
            //    Category => Category.id,
            //    Book => Book.categoryId,
            //    ( Category, Book) => new
            //    {
            //        Category=Category.name,
            //        Book = Book.title
            //    }
            //    );
            var z = _context.categories.AsNoTracking().Where(c=>c.id==id).Include(c => c.Books).FirstOrDefault();
            return Ok(z);
        }
    }
}