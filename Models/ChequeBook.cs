using System;
using System.ComponentModel.DataAnnotations;

namespace Isas.Models
{
    public class ChequeBook
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }
        public int FirstChequeNumber { get; set; }
        public int LastChequeNumber { get; set; }
        public DateTime LastChequeDate { get; set; }
        public short PayeeRow { get; set; }
        public int PayeeCol { get; set; }
        public int PayeeAddressRow { get; set; }
        public int PayeeAddressCol { get; set; }
        public int PayeeCityRow { get; set; }
        public int PayeeCityCol { get; set; }
        public int LetterDateRow { get; set; }
        public int LetterDateCol { get; set; }
        public int SalutationRowRow { get; set; }
        public int SalutationRowCol { get; set; }
        public int TextLineRow { get; set; }
        public int TextLineCol { get; set; }

        [StringLength(100)]
        public string TextLine { get; set; }
        public int TextChequeRow { get; set; }
        public int TextChequeCol { get; set; }
        public int TextAmountRow { get; set; }
        public int TextAmountCol { get; set; }
        public int TransHeaderRow { get; set; }
        public int TransHeaderCol { get; set; }
        public int SignatoryRow { get; set; }
        public int SignatoryCol { get; set; }

        [StringLength(50)]
        public string Signatory { get; set; }

        [StringLength(50)]
        public string Company { get; set; }
        public int CompanyRow { get; set; }
        public int CompanyCol { get; set; }
        public int LineSpacing { get; set; }
        public int ChequePayeeRow { get; set; }
        public int ChequePayeeCol { get; set; }
        public int ChequePayeePad { get; set; }
        public int ChequeDateRow { get; set; }
        public int ChequeDateCol { get; set; }
        public int ChequeWordsRow { get; set; }
        public int ChequeWordsCol { get; set; }
        public int ChequeDigitsRow { get; set; }
        public int ChequeDigitsCol { get; set; }
        public int PaperSize { get; set; }

        [StringLength(50)]
        public string Orientation { get; set; }

        [StringLength(50)]
        public string DefaultPrinter { get; set; }

        public int UserPaperHeight { get; set; }
        public int UserPaperWidth { get; set; }

        [StringLength(50)]
        public string FontName { get; set; }

        public int FontSize { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
