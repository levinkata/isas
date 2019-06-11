using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class PolicyExtractViewModel
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Insurer Insurer { get; set; }
        public Client Client { get; set; }
        public Policy Policy { get; set; }
        public IEnumerable<AllRisk> AllRisks { get; set; }
        public IEnumerable<Commercial> Commercials { get; set; }
        public IEnumerable<Content> Contents { get; set; }
        public IEnumerable<Loan> Loans { get; set; }
        public IEnumerable<Motor> Motors { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
        public IEnumerable<Premium> Premiums { get; set; }
    }
}
