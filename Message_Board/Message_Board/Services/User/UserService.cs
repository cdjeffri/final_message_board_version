using Message_Board.Data;
using Message_Board.Models;
using Message_Board.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Message_Board.Services
{
    public class UserService : IUserService
    {
        private MBDbContext context;
        private IEncryptor encryptor;

        public UserService(IEncryptor encryptor)
        {
            this.encryptor = encryptor;
            this.context = new MBDbContext();
        }

        public void Register(User user)
        {
            user.Privileges = "user";
            user.Password = this.encryptor.Encrypt(user.Password);
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool Authenticate(string username, string password)
        {
            User user = new User();
            if (username != null && password != null)
            {
                string encryptedPassword = this.encryptor.Encrypt(password);
                user = this.context.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == encryptedPassword).SingleOrDefault();
            }

            if (user == null)
                return false;
            else
                return true;
        }

        public bool Exists(string username)
        {
            User user = this.context.Users.Where(x => x.Username.ToLower() == username.ToLower()).SingleOrDefault();

            if (user == null)
                return false;
            else
                return true;
        }

        public bool InputProvided(string input)
        {
            if (input == null)
                return false;
            else
                return true;
        }

        public string GetPrivileges(string username)
        {
            var user = this.context.Users.Where(x => x.Username == username).SingleOrDefault();
            string privileges = user.Privileges;
            return privileges;
        }

        public List<User> GetUsers()
        {
            return this.context.Users.ToList();
        }

        public User GetUser(int id)
        {
            User user = new User();
            user = this.context.Users.Where(x => x.ID == id).SingleOrDefault();
            return user; 
        }

        public void DeleteUser(int id)
        {
            var user = this.context.Users.Where(t => t.ID == id).SingleOrDefault();
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}