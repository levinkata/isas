using Isas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Isas
{
    public class BulkHandles
    {
        public int GetBulkHandle(InsurerDbContext _context)
        {
            var todaydate = DateTime.Now.ToString("yyyyMMdd");
            string dy = todaydate.Substring(6, 2);
            string mn = todaydate.Substring(4, 2);
            string yr = todaydate.Substring(0, 4);

            string seed = yr + mn + dy;
            var myParam = seed + '%';

            string query = "SELECT * FROM BulkHandleGenerator " +
                           "WHERE CAST(BulkNumber AS varchar(9)) LIKE {0}";

            var result = _context.BulkHandleGenerators
                            .FromSql(query, myParam)           
                            .AsNoTracking()
                            .ToList();
            
            string bulkhandle = (result.Count == 0) ? seed + '1' : (_context.BulkHandleGenerators.Max(b => b.BulkNumber) + 1).ToString();

            return int.Parse(bulkhandle);
        }
    }
}
