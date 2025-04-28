using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreApp.Application.DTOs.Book;
using BookStoreApp.Domain.Entities;

namespace BookStoreApp.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();
            // Example:
            CreateMap<Book, BookDto>();
            CreateMap<BookCreateDto, Book>();


        }
    }
}
