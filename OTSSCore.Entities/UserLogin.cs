﻿namespace OTSSCore.Entities
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int Id { get; set; }
    }
}