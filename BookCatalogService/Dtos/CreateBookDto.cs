namespace BookCatalogService.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string? Description { get; set; }
    }

}
