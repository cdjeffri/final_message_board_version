using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Message_Board.Models
{
    public class Thread
    {
        [Key]
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}