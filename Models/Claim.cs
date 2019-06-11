using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class Claim
    {
        [Display(Name = "Claim Number")]
        public int ClaimNumber { get; set; }

        public Guid PolicyID { get; set; }
        public int RiskID { get; set; }
        public Guid RiskItemID { get; set; }
        
        [Display(Name = "Report Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime ReportDate { get; set; }

        [Display(Name = "Incident Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime IncidentDate { get; set; }

        [Display(Name = "Register Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}",
            ApplyFormatInEditMode = false)]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Insured Reserves")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ReserveInsured { get; set; }

        [Display(Name = "Third Party Reserves")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ReserveThirdParty { get; set; }

        [Display(Name = "Insured Revised Reserves")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ReserveInsuredRevised { get; set; }

        [Display(Name = "Third Party Revised Reserves")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ReserveThirdPartyRevised { get; set; }

        [Display(Name = "Excess")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        // [Column(TypeName = "decimal(15,2)")]
        public decimal ClaimExcess { get; set; }

        [Display(Name = "Class")]
        public Guid ClaimClassID { get; set; }

        [Display(Name = "Recover From Third Party")]
        public bool RecoverFromThirdParty { get; set; }

        [Display(Name = "Incident")]
        public Guid IncidentID { get; set; }

        [Display(Name = "Country")]
        public Guid CountryID { get; set; }

        [Display(Name = "Region")]
        public Guid RegionID { get; set; }

        //[Display(Name = "Province")]
        //public Guid? ProvinceID { get; set; }

        [Display(Name = "Status")]
        public Guid ClaimStatusID { get; set; }

        [Display(Name = "Incident Details")]
        [StringLength(100)]
        public string IncidentDetail { get; set; }

        [Display(Name = "Comment")]
        [StringLength(100)]
        public string Comment { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual ClaimClass ClaimClass { get; set; }
        public virtual Incident Incident { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual Region Region { get; set; }
        public virtual Country Country { get; set; }
        public virtual ClaimStatus ClaimStatus { get; set; }

        public virtual ICollection<ClaimDriver> ClaimDrivers { get; set; }
        public virtual ICollection<ClaimThirdParty> ClaimThirdParties { get; set; }
        public virtual ICollection<ClaimTransaction> ClaimTransactions { get; set; }
        public virtual ICollection<ClaimRecovery> ClaimRecoveries { get; set; }
        public virtual ICollection<IncidentContact> IncidentContacts { get; set; }
        public virtual ICollection<ClaimDocumentSubmit> ClaimDocumentSubmits { get; set; }
        public virtual ICollection<ClaimDiary> ClaimDiaries { get; set; }
    }
}
