using Message_Board.Models;
using Message_Board.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Message_Board.Controllers
{
    public class CommentsController : Controller
    {
        private CommentService commentService;
        private ThreadService threadService;
        private Thread thread; 

        public CommentsController()
        {
            this.commentService = new CommentService();
            this.threadService = new ThreadService();
            this.thread = new Thread();
        }

        public ActionResult Index(int id)
        {
            CommentViewModel model = new CommentViewModel();
            model.Comments = this.commentService.GetCommentsByThreadID(id);
            model.ThreadID = id;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var comment = new Comment();
            comment.ThreadID = id;
            return View(comment);
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            Comment com = new Comment();
            comment.Author = this.HttpContext.User.Identity.Name;
            comment.DateTimeCreated = DateTime.Now;
            comment.ThreadID = thread.ID;
            this.commentService.SaveComment(comment);
            return RedirectToAction("Index", "Threads");
        }

        public ActionResult Delete(int id)
        {
            this.commentService.DeleteComment(id);
            return RedirectToAction("Index", "Comments");
        }
    }
}