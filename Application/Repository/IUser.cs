using Application.DTOs.UserDTOs.LoginUser;
using Application.DTOs.UserDTOs.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IUser
    {
        Task<RegisterUserResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);

        Task<LoginUserResponse> LoginUserAsync(LoginUserDTO loginUserDTO);
    }
}
