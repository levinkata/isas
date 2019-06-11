using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public enum UploadFileTypes
    {
        Excel = 1, CSV = 2, FixedLengthDelimited = 3
    }
    public class LoadFormat
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }

        [Required(ErrorMessage = "Please enter the file format.")]
        [StringLength(50, ErrorMessage = "The File Format must be less than {1} characters.")]
        [Display(Name = "File Format")]
        public string Name { get; set; }

        [Display(Name = "File Type")]
        public UploadFileTypes UploadFileType { get; set; }

        [StringLength(1, ErrorMessage = "The Delimiter must not be more than {1} in length.")]
        [Display(Name = "Delimiter")]
        public string Delimiter { get; set; }

        public virtual ICollection<FormatType> FormatTypes { get; set; }
    }
}
