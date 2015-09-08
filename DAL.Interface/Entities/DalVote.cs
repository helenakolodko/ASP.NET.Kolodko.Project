using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class DalVote: IDalEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Up { get; set; }
    }
}
