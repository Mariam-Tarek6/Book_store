using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Model
{
    public class BookStoreDB : DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ShoppingBasket> shoppingBaskets { get; set; }
        public DbSet<ShoppingBasket_Book> shoppingBasket_Books { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Comment> comments { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server = DESKTOP-9VU2GN9;
        //    Database = BookStoreDB;
        //    trusted_connection = true;");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL8004.site4now.net;Initial Catalog=db_a941a2_bookstoredb;User Id=db_a941a2_bookstoredb_admin;Password=MT6102002");
           // optionsBuilder.UseSqlServer(@"Data Source=SQL8002.site4now.net;Initial Catalog=db_a905d8_bookstoredb2;User Id=db_a905d8_bookstoredb2_admin;Password=TSmahmsm6102002");
        }

    }
}
