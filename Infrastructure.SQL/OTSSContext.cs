using Microsoft.EntityFrameworkCore;
using OTSSCore.Entities;

namespace Infrastructure.SQL
{
    public class OTSSContext: DbContext
    {

        public OTSSContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<TShirt> TShirts { get; set; }
    }
}