using BookCatalogService.Dtos;

namespace BookCatalogService.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(Guid id);
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateBookDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
