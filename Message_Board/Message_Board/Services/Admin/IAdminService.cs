using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Board.Services
{
    public interface IAdminService
    {
        List<User> GetUsers();
        List<Thread> GetThreads();
        List<Comment> GetComments();
        void DeleteUser(int id);
        void ChangeUserPrivileges(int id);
        void DeleteThread(int threadID);
    }
}
