using Application.DTOs.UserDTOs.LoginUser;
using Application.DTOs.UserDTOs.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices
{
    public class UserService: IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<LoginUserResponse> LoginUserService(LoginUserDTO loginUserDTO)
        {
            var conn = await httpClient.PostAsJsonAsync("api/user/loginUser", loginUserDTO);
            var result = await conn.Content.ReadFromJsonAsync<LoginUserResponse>();
            return result!;
        }

        public async Task<RegisterUserResponse> RegisterUserService(RegisterUserDTO registerUserDTO)
        {
            var conn = await httpClient.PostAsJsonAsync("api/user/registerUser", registerUserDTO);
            var result = await conn.Content.ReadFromJsonAsync<RegisterUserResponse>();
            return result!;
        }
    }
}
