using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommentSystem.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ParentId { get; set; }
        public string CommentText { get; set; }
        public string Username { get; set; }
        public DateTime CommentDate { get; set; }
    }

    public class commentViewModel : Comment
    {
        public int commentId { get; set; }
        //public DateTime CommentDate { get; set; }
        public string strCommentDate { get {; return this.CommentDate.ToString("dd-MM-yyyy"); } }
    }
}

