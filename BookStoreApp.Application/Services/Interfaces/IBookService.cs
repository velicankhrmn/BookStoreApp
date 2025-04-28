using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApp.Application.DTOs.Book;

namespace BookStoreApp.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int id);
        Task<BookDto> CreateAsync(BookCreateDto bookDto);
        Task<bool> UpdateAsync(int id, BookCreateDto bookDto);
        Task<bool> DeleteAsync(int id);
    }
}
