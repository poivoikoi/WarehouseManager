using System;
using System.Linq;

namespace WarehouseManager1._2.Data
{
    public class DataLayer
    {
        private readonly WarehouseDbContext _dbContext;

        public DataLayer()
        {
            _dbContext = new WarehouseDbContext();
        }

        public bool RegisterUser(string username, string password)
        {
            try
            {
                if (_dbContext.Users.Any(u => u.Username == username))
                {
                    return false;
                }

                var newUser = new User
                {
                    Username = username,
                    Password = HashPassword(password),
                    UserType = "Buyer"
                };

                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}

