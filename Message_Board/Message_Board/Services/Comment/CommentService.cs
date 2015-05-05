using Message_Board.Data;
using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Message_Board.Services
{
    public class CommentService : ICommentService
    {
        private MBDbContext context;
        private Thread thread; 
 
        public CommentService()
        {
            this.context = new MBDbContext();
            this.thread = new Thread();
        }

        public List<Comment> GetComments()
        {
            List<Comment> comments = new List<Comment>();
            comments = this.context.Comments.ToList();

            List<Comment> orderedComments = new List<Comment>();
            orderedComments = comments.OrderByDescending(c => c.DateTimeCreated).ToList();
            return orderedComments; 
        }

        public List<Comment> GetCommentsByThreadID(int threadID)
        {
            List<Comment> comments = new List<Comment>();
            comments = this.context.Comments.Where(c => c.ThreadID == threadID).ToList();

            List<Comment> orderedComments = new List<Comment>();
            orderedComments = comments.OrderByDescending(c => c.DateTimeCreated).ToList();

            return orderedComments; 
        }

        public Comment GetCommentById(int id)
        {
            return this.context.Comments.Where(c => c.ID == id).SingleOrDefault();
        }

        public void SaveComment(Comment comment)
        {
            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = this.context.Comments.Where(c => c.ID == id).SingleOrDefault();
            this.context.Comments.Remove(comment);
            this.context.SaveChanges();
        }
    }
}