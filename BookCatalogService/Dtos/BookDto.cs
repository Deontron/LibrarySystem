namespace BookCatalogService.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
