using Message_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Board.Services
{
    public interface ICommentService
    {
        List<Comment> GetComments();
        List<Comment> GetCommentsByThreadID(int threadID);
        Comment GetCommentById(int id);
        void SaveComment(Comment commnet);
        void DeleteComment(int id);
    }
}
