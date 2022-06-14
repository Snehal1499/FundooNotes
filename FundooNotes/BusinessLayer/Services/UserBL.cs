﻿using BussinessLayer.Interfaces;
using DataBaseLayer.Users;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                this.userRL.AddUser(userPostModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ForgetPassword(string Email)
        {
            try
            {
                return this.userRL.ForgetPassword(Email);
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
                return this.userRL.LoginUser(Email, Password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(string Email, PasswordModel passwordModel)
        {
            try
            {
                return this.userRL.ResetPassword(Email, passwordModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}