using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.Login
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]

        public string Password { get; set; }
    }
}
