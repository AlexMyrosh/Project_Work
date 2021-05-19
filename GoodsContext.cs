using Microsoft.EntityFrameworkCore;

namespace Project_Work
{
    class GoodsContext : DbContext
    {
        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Product> Products { get; set; }

        public GoodsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GoodsDB;Trusted_Connection=True");
        }
    }
}