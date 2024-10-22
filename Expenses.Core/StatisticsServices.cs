using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Core
{
    public class StatisticsServices : IStatisticsServices
    {
        private readonly DB.AppDbContext _context;
        public StatisticsServices(DB.AppDbContext context) 
        { 
            _context = context;
        }
        public IEnumerable<KeyValuePair<string, double>> GetExpenseAmountPerCategory()
        { try
            {
                return _context.Expenses.AsEnumerable().GroupBy(e => e.Description).ToDictionary(e => e.Key, e => e.Sum(x => x.Amount))
                     .Select(x => new KeyValuePair<string, double>(x.Key, x.Value));
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the statistics. {ex.Message}");
            }
        }
        
    }
}
