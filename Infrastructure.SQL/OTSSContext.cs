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
        }


        public DbSet<TShirt> TShirts { get; set; }
    }
}