using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class DalComment:IDalEntity
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Text { get; set; }
    }
}
