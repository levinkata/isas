using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class AuthoriseViewModel
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<ClaimTransaction> Authorised { get; set; }
        public IEnumerable<ClaimTransaction> UnAuthorised { get; set; }
    }
}
