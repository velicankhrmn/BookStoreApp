using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApp.Application.DTOs.Book;
using BookStoreApp.Application.Services.Interfaces;
using BookStoreApp.Domain.Entities;
using BookStoreApp.Infrastructure.Context;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Application.Services.Implementations
{
    class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BookCreateDto>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            var bookDtos = books.Select(b => new BookCreateDto
            {
                Title = b.Title,
                Author = b.Author,
                Price = b.Price,
                Stock = b.Stock,
                PublishedDate = b.PublishedDate,
                Description = b.Description,
                ISBN = b.ISBN,
                CoverImageUrl = b.CoverImageUrl,
                CategoryId = b.CategoryId
            }).ToList();

            return bookDtos;
        }

        public async Task<BookCreateDto> GetByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return null;

            return new BookCreateDto
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
                PublishedDate = book.PublishedDate,
                Description = book.Description,
                ISBN = book.ISBN,
                CoverImageUrl = book.CoverImageUrl,
                CategoryId = book.CategoryId
            };
        }

        public async Task<BookCreateDto> CreateAsync(BookCreateDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Price = bookDto.Price,
                Stock = bookDto.Stock,
                PublishedDate = bookDto.PublishedDate,
                Description = bookDto.Description,
                ISBN = bookDto.ISBN,
                CoverImageUrl = bookDto.CoverImageUrl,
                CategoryId = bookDto.CategoryId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return bookDto;
        }

        public Task<bool> UpdateAsync(int id, BookCreateDto bookDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
