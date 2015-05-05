using Message_Board.Models;
using Message_Board.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Message_Board.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController()
        {
            var encryptor = new SHA256Encryptor();
            userService = new UserService(encryptor);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            bool usernameExists = this.userService.Exists(model.Username);
            bool usernameProvided = this.userService.InputProvided(model.Username);
            bool passwordProvided = this.userService.InputProvided(model.Password);
            bool isAuthenticated = this.userService.Authenticate(model.Username, model.Password);
 
            if (!usernameExists)
            {
                this.ModelState.AddModelError("", "Username doesn't exist");
                return View(model);
            }
            else if (!usernameProvided || !passwordProvided || !isAuthenticated)
            {
                this.ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                string privileges = this.userService.GetPrivileges(model.Username);

                if (privileges == "admin")
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            bool exists = this.userService.Exists(user.Username);
            bool usernameProvided = this.userService.InputProvided(user.Username);
            bool passwordProvided = this.userService.InputProvided(user.Password);
            bool emailProvided = this.userService.InputProvided(user.Email);

            if (exists)
            {
                this.ModelState.AddModelError("", "Username already exists"); 
                return View(); 
            }
            else if (usernameProvided == false || passwordProvided == false || emailProvided == false)
            {
                this.ModelState.AddModelError("", "Missing user input");
                return View();
            }
            else
            {
               try 
               { 
                   this.userService.Register(user); 
               } 
               catch (Exception ex) 
               { 
                   this.ModelState.AddModelError("", "An error has occured"); 
                   return View(); 
               }               
 
               return RedirectToAction("Index", "Home"); 
            }
        }
    }
}