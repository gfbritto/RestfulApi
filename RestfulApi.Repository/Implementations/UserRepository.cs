using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;
using RestfulApi.Repository.Interfaces;
using RestfulApi.Repository.Persistence;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestfulApi.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly RestfulApiDbContext _dbContext;

        public UserRepository(RestfulApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User RefreshUserInfo(User user)
        {
            var hasUser = _dbContext.Users.Any(u => u.Id.Equals(user.Id));
            if (!hasUser)
            {
                return null;
            }

            var result = _dbContext.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
            if (result != null)
            {
                _dbContext.Entry(result).CurrentValues.SetValues(user);
                _dbContext.SaveChanges();
                return result;
            }
            return result;
        }

        public User ValidateCredentials(UserVO user)
        {
            var hashedPassword = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _dbContext.Users
                .FirstOrDefault(u => u.UserName.Equals(user.UserName)
                && u.Password.Equals(hashedPassword));
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User ValidateCredentials(string userName)
        {
            return _dbContext.Users.SingleOrDefault(user => user.UserName.Equals(userName));
        }

        public bool RevokeToken(string userName)
        {
            var user = _dbContext.Users
                .SingleOrDefault(user => user.UserName.Equals(userName)
            );

            if (user is null)
            {
                return false;
            }
            user.RefreshToken = null;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
