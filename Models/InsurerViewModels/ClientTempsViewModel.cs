using Isas.Data;
using System;
using System.Collections.Generic;

namespace Isas.Models.InsurerViewModels
{
    public class ClientTempsViewModel
    {
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public IEnumerable<ClientTemp> ClientTemps { get; set; }
    }
}
