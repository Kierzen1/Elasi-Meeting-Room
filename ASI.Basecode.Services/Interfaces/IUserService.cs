﻿using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System.Collections.Generic;
using static ASI.Basecode.Resources.Constants.Enums;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IUserService
    {
        LoginResult AuthenticateUser(string userid, string password, ref User user);
        void AddUser(UserViewModel model);

        (bool result, IEnumerable<User> users) GetUsers();

        void UpdateUser(User user);
        void DeleteUser(User user);

        void RegisterUser(User user);
    }
}
