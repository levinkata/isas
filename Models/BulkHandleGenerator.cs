using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class BulkHandleGenerator
    {
        public int BulkNumber { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        public DateTime BulkDate { get; set; }
        public int RecordCount { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid AddedBy { get; set; }
    }
}
