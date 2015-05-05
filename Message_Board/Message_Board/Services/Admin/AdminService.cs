using Message_Board.Data;
using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Message_Board.Services
{
    public class AdminService : IAdminService
    {
        private MBDbContext context;
        private SHA256Encryptor encryptor;
        private UserService userService;
        private ThreadService threadService;
        private CommentService commentService;

        public AdminService()
        {
            this.context = new MBDbContext();
            this.encryptor = new SHA256Encryptor();
            this.userService = new UserService(encryptor);
            this.threadService = new ThreadService();
            this.commentService = new CommentService();
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = this.userService.GetUsers();
            return users;
        }

        public List<Thread> GetThreads()
        {
            List<Thread> threads = new List<Thread>();
            threads = this.threadService.GetThreads("");
            return threads; 
        }

        public List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();
            comments = this.commentService.GetComments();
            return comments;
        }

        public void DeleteUser(int id)
        {
            this.userService.DeleteUser(id);
        }

        public void ChangeUserPrivileges(int id)
        {
            User user = new User();
            user = this.userService.GetUser(id);
            if (user.Privileges == "admin")
                user.Privileges = "user";
            else if (user.Privileges == "user")
                user.Privileges = "admin";
            this.context.SaveChangesAsync();
        }

        public void DeleteThread(int threadID)
        {
            this.threadService.DeleteThread(threadID);
        }
    }
}