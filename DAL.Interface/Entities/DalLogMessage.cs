using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class DalLogMessage: IDalEntity
    {
        public int Id { get; set; }
        public DateTime TimeOccured { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
