using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Model;

namespace WebApplication4.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientRegister, Client>();
            CreateMap<ClientLogin, Client>();
            CreateMap<CategoryAdd, Category>();
            CreateMap<Book, BookView>();
            CreateMap<Book, BookDtO>();
            CreateMap<BookDtO, Book>();
            CreateMap<BookView, Book>();
            CreateMap<AuthorAdd, Author>();
        }
    }
}
