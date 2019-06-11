using Isas.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Isas
{
    public class TransactionNumbers
    {
        public int GetTransactionNumber(InsurerDbContext _context)
        {
            string query = "SELECT * FROM ClaimTransactionGenerator " +
                           "WHERE TransactionNumber IN (SELECT MAX(TransactionNumber) " +
                           "FROM ClaimTransactionGenerator)";

            var result = _context.ClaimTransactionGenerators
                            .FromSql(query)
                            .AsNoTracking()
                            .ToList();

            return (result.Count == 0) ? 1 : _context.ClaimTransactionGenerators.Max(b => b.TransactionNumber) + 1;
        }
    }
}
