using Message_Board.Data;
using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Message_Board.Services
{
    public class ThreadService : IThreadService
    {
        private MBDbContext context; 

        public ThreadService()
        {
            this.context = new MBDbContext();
        }
        
        public List<Thread> GetThreads(string searchString)
        {
            List<Thread> threads = new List<Thread>();
            if (!String.IsNullOrEmpty(searchString))
                threads = this.context.Threads.Where(t => t.Title.Contains(searchString)).ToList();
            else
                threads = this.context.Threads.ToList();

            List<Thread> orderedThreads = new List<Thread>();
            orderedThreads = threads.OrderByDescending(t => t.DateTimeCreated).ToList();
            return orderedThreads;
        }

        public Thread GetThreadByID(int id)
        {
            return this.context.Threads.Where(t => t.ID == id).SingleOrDefault();
        }

        public void SaveThread(Thread thread)
        {
            this.context.Threads.Add(thread);
            this.context.SaveChanges();
        }

        public void DeleteThread(int id)
        {
            var thread = this.context.Threads.Where(t => t.ID == id).SingleOrDefault();
            this.context.Threads.Remove(thread);
            this.context.SaveChanges();
        }
    }
}