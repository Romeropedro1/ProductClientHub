using Microsoft.EntityFrameworkCore;
using ProductclientHub.api.Entidads;


namespace ProductClienthub.api.Infrastructure
{
    public class ProductClientHubDBContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ensure the path is correct and SQLite database file is accessible
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ALEXIENIGENA\\Downloads\\1737062251373-attachment.octet-stream");
        }
    }
}
