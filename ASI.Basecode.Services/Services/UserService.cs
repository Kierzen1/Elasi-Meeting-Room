﻿    using ASI.Basecode.Data.Interfaces;
    using ASI.Basecode.Data.Models;
    using ASI.Basecode.Data.Repositories;
    using ASI.Basecode.Services.Interfaces;
    using ASI.Basecode.Services.Manager;
    using ASI.Basecode.Services.ServiceModels;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using static ASI.Basecode.Resources.Constants.Enums;

    namespace ASI.Basecode.Services.Services
    {
        public class UserService : IUserService
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;

            public UserService(IUserRepository repository, IMapper mapper)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public LoginResult AuthenticateUser(string userId, string password, ref User user)
            {
                user = new User();
                var passwordKey = PasswordManager.EncryptPassword(password);
                user = _repository.GetUsers().Where(x => x.UserId == userId &&
                                                         x.Password == passwordKey).FirstOrDefault();

                return user != null ? LoginResult.Success : LoginResult.Failed;
            }

            public void AddUser(UserViewModel model)
            {
                var user = new User();
                if (!_repository.UserExists(model.UserId))
                {
                    _mapper.Map(model, user);
                    user.Password = PasswordManager.EncryptPassword(model.Password);
                    user.CreatedTime = DateTime.Now;
                    user.UpdatedTime = DateTime.Now;
                    user.CreatedBy = System.Environment.UserName;
                    user.UpdatedBy = System.Environment.UserName;

                    _repository.AddUser(user);
                }
                else
                {
                    throw new InvalidDataException(Resources.Messages.Errors.UserExists);
                }

            }
            public (bool, IEnumerable<User>) GetUsers()
            {

                var users = _repository.ViewUsers();
                if (users != null)
                {
                    return (true, users);
                }
                return (false, null);
            }
            public void DeleteUser(User user)
            {
                if (user == null)
                {
                    throw new ArgumentException();
                }


                _repository.DeleteUser(user);
            }

            public void UpdateUser(User user)
            {
                if (user == null)
                {
                    throw new ArgumentException();
                }


                _repository.UpdateUser(user);
            }

            public void RegisterUser(User user)
            {
                if (user == null)
                {
                    throw new ArgumentException();
                }
                var newUser = new User();
                newUser.UserId = user.UserId;
                newUser.Name = user.Name;
                newUser.Email = user.Email;
                newUser.Role = user.Role;
             newUser.Password = user.Password;
                newUser.CreatedTime = DateTime.Now;
                newUser.UpdatedTime = DateTime.Now;
                newUser.CreatedBy = System.Environment.UserName;
                newUser.UpdatedBy = System.Environment.UserName;
                _repository.RegisterUser(newUser);

            }



        }
    }
