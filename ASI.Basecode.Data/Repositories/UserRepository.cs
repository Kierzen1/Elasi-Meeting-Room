using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        List<User> _allUser = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public UserRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> ViewUsers()
        {
            return _dbContext.Users.ToList();
        }

        public IQueryable<User> GetUsers()
        {
            return this.GetDbSet<User>();
        }

        public bool UserExists(string userId)
        {
            return this.GetDbSet<User>().Any(x => x.UserId == userId);
        }

        public void AddUser(User user)
        {
            this.GetDbSet<User>().Add(user);
            UnitOfWork.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(r => r.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.UserId = user.UserId;
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.Password = user.Password;

                _dbContext.Users.Update(existingUser);
                _dbContext.SaveChanges();

            }
        }

        public void RegisterUser(User user)
        {
            this.GetDbSet<User>().Add(user);
            UnitOfWork.SaveChanges();
        }

    }
}
