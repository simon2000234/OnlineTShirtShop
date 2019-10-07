using OTSSCore.Entities;

namespace Infrastructure.SQL
{
    public class DbInitializer
    {
        public static void SeedDB(OTSSContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var TShirt1 = ctx.Add(new TShirt()
            {
                Color = "Blue",
                Id = 1,
                IsMan = true,
                Price = 420,
                Size = "L",
                Type = "TankTop"
            }).Entity;

            var TShirt2 = ctx.Add(new TShirt()
            {
                Color = "Green",
                Id = 2,
                IsMan = false,
                Price = 69.69,
                Size = "M",
                Type = "Normal"
            }).Entity;


            ctx.SaveChanges();
        }
    }
}