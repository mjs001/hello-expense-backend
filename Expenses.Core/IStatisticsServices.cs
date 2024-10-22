using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Core
{
   public interface IStatisticsServices
    {
        IEnumerable<KeyValuePair<string, double>> GetExpenseAmountPerCategory();
    }
}
