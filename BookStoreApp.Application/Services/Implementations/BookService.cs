using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreApp.Application.DTOs.Book;
using BookStoreApp.Application.Services.Interfaces;
using BookStoreApp.Domain.Entities;
using BookStoreApp.Infrastructure.Context;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Application.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return null;

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateAsync(BookCreateDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> UpdateAsync(int id, BookCreateDto bookDto)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return false;

            _mapper.Map(bookDto, book);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
