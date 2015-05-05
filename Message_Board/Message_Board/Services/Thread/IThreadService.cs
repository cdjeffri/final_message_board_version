using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Board.Services
{
    public interface IThreadService
    {
        List<Thread> GetThreads(string searchString);
        Thread GetThreadByID(int id);
        void SaveThread(Thread thread);
        void DeleteThread(int id);  
    }
}
