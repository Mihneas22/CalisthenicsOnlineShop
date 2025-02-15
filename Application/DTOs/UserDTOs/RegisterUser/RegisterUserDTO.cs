using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs.RegisterUser
{
    public class RegisterUserDTO
    {
        [Required]
        public string username { get; set; } = string.Empty;

        [Required]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required, Compare(nameof(password))]
        public string confirmPassword { get; set; } = string.Empty;
    }
}
