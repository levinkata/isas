using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Isas
{
    public class PolicyExpiryDate
    {
        public DateTime GetOption(DateTime effectiveDate, int option)
        {
            DateTime expiryDate = effectiveDate;

            switch (option)
            {
                case 1:
                    expiryDate = effectiveDate.AddMonths(1);
                    break;
                case 2:
                    expiryDate = effectiveDate.AddMonths(2);
                    break;
                case 3:
                    expiryDate = effectiveDate.AddMonths(3);
                    break;
                case 4:
                    expiryDate = effectiveDate.AddMonths(4);
                    break;
                case 5:
                    expiryDate = effectiveDate.AddMonths(6);
                    break;
                case 6:
                    expiryDate = effectiveDate.AddMonths(9);
                    break;
                case 7:
                    expiryDate = effectiveDate.AddYears(1);
                    break;
                case 8:
                    expiryDate = effectiveDate.AddYears(3);
                    break;
                case 9:
                    expiryDate = effectiveDate.AddYears(5);
                    break;
                default:
                    break;
            }

            return expiryDate.Date;
        }
    }
}
