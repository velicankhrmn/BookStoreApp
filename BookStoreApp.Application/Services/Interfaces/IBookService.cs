using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApp.Application.DTOs.Book;

namespace BookStoreApp.Application.Services.Interfaces
{
    interface IBookService
    {
        Task<List<BookCreateDto>> GetAllAsync();
        Task<BookCreateDto> GetByIdAsync(int id);
        Task<BookCreateDto> CreateAsync(BookCreateDto bookDto);
        Task<bool> UpdateAsync(int id, BookCreateDto bookDto);
        Task<bool> DeleteAsync(int id);
    }
}
