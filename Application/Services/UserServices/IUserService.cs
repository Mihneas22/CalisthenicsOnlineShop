using Application.DTOs.UserDTOs.LoginUser;
using Application.DTOs.UserDTOs.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices
{
    public interface IUserService
    {
        Task<LoginUserResponse> LoginUserService(LoginUserDTO loginUserDTO);

        Task<RegisterUserResponse> RegisterUserService(RegisterUserDTO registerUserDTO)
    }
}
