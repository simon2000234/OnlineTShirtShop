﻿using OTSSCore.Entities;

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

            string password = "password";
            byte[] passwordHashUserOne, passwordSaltUserOne, passwordHashUserTwo, passwordSaltUserTwo;

            CreatePasswordHash(password, out passwordHashUserOne, out passwordSaltUserOne);
            CreatePasswordHash(password, out passwordHashUserTwo, out passwordSaltUserTwo);

            var userNormal = ctx.Users.Add(new User()
            {
                IsAdmin = false,
                Username = "DabNormal",
                PasswordSalt = passwordSaltUserOne,
                PasswordHash = passwordHashUserOne
            }).Entity;

            var userAdmin = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Username = "DabAdmin",
                PasswordSalt = passwordSaltUserTwo,
                PasswordHash = passwordHashUserTwo
            }).Entity;

            ctx.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}