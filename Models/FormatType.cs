using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class FormatType
    {
        public Guid ID { get; set; }
        public Guid LoadFormatID { get; set; }

        [Display(Name = "Table")]
        [StringLength(50)]
        public string TableName { get; set; }

        [Display(Name = "Field Name")]
        [StringLength(50)]
        public string FieldName { get; set; }

        [Display(Name = "Field Label")]
        [StringLength(50)]
        public string FieldLabel { get; set; }

        [Display(Name = "Position")]
        [RegularExpression("^[A-Z0-9]")]
        [StringLength(50)]
        public string Position { get; set; }

        [Display(Name = "Column Length")]
        public int ColumnLength { get; set; }

        [Display(Name = "Unique Key")]
        public bool IsKey { get; set; }

        public virtual LoadFormat LoadFormat { get; set; }
    }
}
