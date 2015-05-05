using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Board.Services
{
    public interface IUserService
    {
        void Register(User user);
        bool Authenticate(string username, string password);
        bool Exists(string username);
        bool InputProvided(string input);
        string GetPrivileges(string username);
        List<User> GetUsers();
        User GetUser(int id);
        void DeleteUser(int id);
    }
}
