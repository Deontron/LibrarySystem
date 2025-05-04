namespace BookCatalogService.Dtos
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
