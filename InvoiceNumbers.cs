using Isas.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Isas
{
    public class InvoiceNumbers
    {
        private readonly InsurerDbContext _context;

        public InvoiceNumbers(InsurerDbContext context)
        {
            _context = context;
        }

        public int GetInvoiceNumber()
        {
            int InvoiceNumber = 1000000000;
            string query = "SELECT * FROM InvoiceNumberGenerator";

            var result = _context.InvoiceNumberGenerators
                            .FromSql(query)
                            .AsNoTracking()
                            .ToList();

            return (result.Count() > 0) ? _context.InvoiceNumberGenerators.Max(i => i.InvoiceNumber) + 1 : InvoiceNumber;
        }
    }
}
