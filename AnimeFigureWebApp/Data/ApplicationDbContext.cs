using AnimeFigureWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeFigureWebApp.Data
{
   
    public class ApplicationDbContext : DbContext
    {

        public DbSet<AnimeFigure> Figures { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AnimeFigureWebApp.Models.Type> Types { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { base.OnConfiguring(optionsBuilder); }

    }

}
