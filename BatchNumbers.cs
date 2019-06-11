using Isas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Isas
{
    public class BatchNumbers
    {
        private readonly InsurerDbContext _context;

        public BatchNumbers(InsurerDbContext context)
        {
            _context = context;
        }
        
        public int GetBatchNumber()
        {
            var todaydate = DateTime.Now.ToString("yyyyMMdd");
            string dy = todaydate.Substring(6, 2);
            string mn = todaydate.Substring(4, 2);
            string yr = todaydate.Substring(0, 4);

            string seed = yr + mn + dy;
            int BatchNumber = int.Parse(seed + '1');
            var myParam = seed + '%';

            string query = "SELECT * FROM BatchNumberGenerator " +
                           "WHERE CAST(BatchNumber AS varchar(9)) LIKE {0}";

            var result = _context.BatchNumberGenerators
                            .FromSql(query, myParam)
                            .AsNoTracking()
                            .ToList();
                        
            if (result.Count() > 0)
                BatchNumber = _context.BatchNumberGenerators.Max(b => b.BatchNumber) + 1;

            return BatchNumber;
        }
    }
}
