
namespace BookCatalogService.Entities
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
