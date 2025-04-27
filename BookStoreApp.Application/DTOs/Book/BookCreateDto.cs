using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Application.DTOs.Book
{
    public class BookCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }

    }
}
