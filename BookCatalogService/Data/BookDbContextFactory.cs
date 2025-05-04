using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookCatalogService.Data
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
        public BookDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookDbContext>();
            optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=library;Username=postgres;Password=postgres");
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library;Username=postgres;Password=5.deonGELDI");

            return new BookDbContext(optionsBuilder.Options);
        }
    }
}
