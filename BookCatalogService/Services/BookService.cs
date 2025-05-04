using BookCatalogService.Dtos;
using BookCatalogService.Entities;
using BookCatalogService.Data;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogService.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            return await _context.Books
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    IsAvailable = b.IsAvailable,
                    CreatedAt = b.CreatedAt
                }).ToListAsync();
        }

        public async Task<BookDto?> GetByIdAsync(Guid id)
        {
            var b = await _context.Books.FindAsync(id);
            if (b == null) return null;

            return new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                IsAvailable = b.IsAvailable,
                CreatedAt = b.CreatedAt
            };
        }

        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Description = dto.Description,
                IsAvailable = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                IsAvailable = book.IsAvailable,
                CreatedAt = book.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateBookDto dto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Description = dto.Description;
            book.IsAvailable = dto.IsAvailable;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
