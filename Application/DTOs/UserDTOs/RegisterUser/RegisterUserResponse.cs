using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs.RegisterUser
{
    public record RegisterUserResponse(bool Flag, string message = null!);
}
