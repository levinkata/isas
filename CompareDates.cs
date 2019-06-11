using Isas.Data;
using System;
using System.Linq;

namespace Isas
{
    public class CompareDates
    {
        private readonly InsurerDbContext _context;

        public CompareDates(InsurerDbContext context)
        {
            _context = context;
        }

        public int CompareStartDate(Guid policyId, DateTime compareDate)
        {
            var PolicyDate = _context.Policies.SingleOrDefault(p => p.ID == policyId).EffectiveDate;

            int result = DateTime.Compare(compareDate, PolicyDate);
            return result;
        }

        public int CompareEndDate(Guid policyId, DateTime compareDate)
        {
            var PolicyDate = _context.Policies.SingleOrDefault(p => p.ID == policyId).ExpireDate;

            int result = DateTime.Compare(compareDate, PolicyDate);
            return result;
        }
    }
}
