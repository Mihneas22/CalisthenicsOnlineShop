using Application.DTOs.UserDTOs.LoginUser;
using Application.DTOs.UserDTOs.RegisterUser;
using Application.Repository;
using Domain.Models;
using Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;

        public UserRepository(ApplicationDbContext dbContext,IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.username!),
                new Claim(ClaimTypes.Email, user.email!),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginUserResponse> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            if (loginUserDTO == null)
                return new LoginUserResponse(false, "Invalid data entered");

            var user = await dbContext.userEntity!.FirstOrDefaultAsync(u => u.email == loginUserDTO.email);
            if(user == null)
                return new LoginUserResponse(false, "User with email does not exist");

            bool checkPass = BCrypt.Net.BCrypt.Verify(loginUserDTO.password, user.password);
            if (checkPass)
            {
                string token = GenerateJWTToken(user);
                return new LoginUserResponse(true, "Logare cu succes!", token);
            }
            else
                return new LoginUserResponse(false, "Date invalide");
        }

        public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            if (registerUserDTO == null)
                return new RegisterUserResponse(false, "Invalid data entered");

            var user = await dbContext.userEntity!.FirstOrDefaultAsync(u => u.email == registerUserDTO.email || u.username == registerUserDTO.username);
            if(user != null)
                return new RegisterUserResponse(false, "User with name/email already exists");

            dbContext.Add(new User
            {
                username = registerUserDTO.username,
                email = registerUserDTO.email,
                password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.password),
                points = 0,
                city = string.Empty,
                country = string.Empty,
                itemsBoughtHistory = new List<string>(),
                shoppingCart = new List<string>(),
                createdAccount = DateTime.Now
            });

            await dbContext.SaveChangesAsync();

            return new RegisterUserResponse(true, "Succesfull Register!");
        }
    }
}
