using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Message_Board.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public int ThreadID { get; set; }
        public string CommentMessage { get; set; }
        public string Author { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}