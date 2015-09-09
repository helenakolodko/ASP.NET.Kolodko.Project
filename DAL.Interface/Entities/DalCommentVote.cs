using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class DalCommentVote
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public bool Up { get; set; }
    }
}
