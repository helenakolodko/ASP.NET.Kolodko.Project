﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class DalTopicVote
    {
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public bool Up { get; set; }
    }
}
