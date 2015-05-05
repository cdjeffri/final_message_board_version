using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Message_Board.Models
{
    public class CommentViewModel
    {
        public List<Comment> Comments { get; set; }
        public int ThreadID { get; set; }
    }
}