﻿using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class UserServiceRequestDto
    {
        public int IdProfile { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public int? IdClient { get; set; }
    }
}
