﻿namespace ViteNetCoreApp.Domain.Models.DTOs
{
    public class UserLoginDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
