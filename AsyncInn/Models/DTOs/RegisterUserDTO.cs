﻿using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Services
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}