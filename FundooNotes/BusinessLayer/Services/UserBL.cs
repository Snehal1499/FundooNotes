using BussinessLayer.Interfaces;
using DataBaseLayer.Users;
using RepositoryLayer.Interfaces;
using System;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;
        public UserBL(IUserRL userRl)
        {
            this.userRl = userRl;
        }

        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                this.userRl.AddUser(userPostModel);
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
                return this.userRl.LoginUser(Email, Password);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}