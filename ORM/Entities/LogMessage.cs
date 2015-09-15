namespace ORM.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogMessages")]
    public class LogMessage
    {
        public int Id { get; set; }

        [Required]
        public DateTime TimeOccured { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
