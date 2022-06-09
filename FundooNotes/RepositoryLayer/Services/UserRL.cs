using DataBaseLayer.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext Fundoocontext;
        IConfiguration configuration;

        public UserRL(FundooContext fundoocontext, IConfiguration configuration)
        {
            this.Fundoocontext = fundoocontext;
            this.configuration = configuration;
        }
        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                User user = new User();
                user.FirstName = userPostModel.FirstName;
                user.LastName = userPostModel.LastName;
                user.Email = userPostModel.Email;
                user.Password = userPostModel.Password;
                user.Address = userPostModel.Address;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                Fundoocontext.Add(user);
                Fundoocontext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string LoginUser(string Email, string Password)
        {
            try
            {
                var user = Fundoocontext.User.FirstOrDefault(u => u.Email == Email && u.Password == Password);
                if (user != null)
                {
                    return GenerateJWToken(Email, user.UserId);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string GenerateJWToken(string Email, int userId)
        {
            var user = Fundoocontext.User.FirstOrDefault(u => u.Email == Email);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                    new Claim("userId",userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}