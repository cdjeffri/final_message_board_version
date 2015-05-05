using Message_Board.Models;
using Message_Board.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Message_Board.Controllers
{
    public class AdminController : Controller
    {
        private SHA256Encryptor encryptor;
        private UserService userService;
        private AdminService adminService;
        private ThreadService threadService;

        public AdminController()
        {
            this.encryptor = new SHA256Encryptor();
            this.userService = new UserService(encryptor);
            this.adminService = new AdminService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            List<User> users = new List<User>();
            users = this.adminService.GetUsers();
            return View(users);
        }

        public ActionResult Threads()
        {
            List<Thread> threads = new List<Thread>();
            threads = this.adminService.GetThreads();
            return View(threads);
        }

        public ActionResult Comments()
        {
            List<Comment> comments = new List<Comment>();
            comments = this.adminService.GetComments();
            return View(comments);
        }

        public ActionResult DeleteUser(int id)
        {
            adminService.DeleteUser(id);
            return RedirectToAction("Users", "Admin");
        }

        public ActionResult DeleteThread(int id)
        {
            threadService.DeleteThread(id);
            return View();
        }

        public ActionResult ChangeUserPrivileges(int id)
        {
            adminService.ChangeUserPrivileges(id);
            return RedirectToAction("Users", "Admin");
        }
    }
}