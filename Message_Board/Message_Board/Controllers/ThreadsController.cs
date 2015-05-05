using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Message_Board.Data;
using Message_Board.Models;
using Message_Board.Services;

namespace Message_Board.Controllers
{
    public class ThreadsController : Controller
    {
        private ThreadService threadService;

        public ThreadsController()
        {
            this.threadService = new ThreadService();
        }

        public ActionResult Index(string searchString)
        {
            List<Thread> threads = this.threadService.GetThreads(searchString);
            int threadCount = threads.Count();

            if (threadCount != 0 && threads != null)
                return View(threads);
            else
                return View("Search");
        }

        public ActionResult ViewComments()
        {
            return RedirectToAction("Index", "Comments");
        }

       [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Thread thread)
        {
            thread.Author = this.HttpContext.User.Identity.Name;
            thread.DateTimeCreated = DateTime.Now;
            this.threadService.SaveThread(thread);
            return RedirectToAction("Index", "Threads");
        }

        public ActionResult Delete(int id)
        {
            this.threadService.DeleteThread(id);
            return RedirectToAction("Index", "Threads");
        }
    }
}
