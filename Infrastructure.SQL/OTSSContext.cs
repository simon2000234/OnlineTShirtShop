using Microsoft.EntityFrameworkCore;
using OTSSCore.Entities;

namespace Infrastructure.SQL
{
    public class OTSSContext: DbContext
    {

        public OTSSContext(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TShirt>().HasKey(ts => ts.Id);
            modelBuilder.Entity<User>().HasKey(us => us.Id);
        }


        public DbSet<TShirt> TShirts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}