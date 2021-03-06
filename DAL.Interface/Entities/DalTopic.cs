﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class DalTopic: IDalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int? SectionId { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
