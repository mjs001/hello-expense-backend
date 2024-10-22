using Expenses.DB;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace Expenses.Core
{
    public class ExpensesServices : IExpensesServices
    {
       
            private AppDbContext _context;
            public ExpensesServices(AppDbContext context)
            {
                _context  = context;
            }

        public Expense CreateExpense(Expense expense)
        {
            try
            {

                _context.Add(expense);
                _context.SaveChanges();
                return expense;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the expense. {ex.Message}");
            }
        }

        public void DeleteExpense(int id)
        {
            try
            {
                var expenseToDelete = _context.Expenses.First(e => e.Id == id);
                _context.Expenses.Remove(expenseToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the expense. {ex.Message}");
    }
}

        public Expense EditExpense(Expense expense)
        {
            try { 
            var dbExpense = _context.Expenses.First(e => e.Id == expense.Id);
            dbExpense.Date = expense.Date;
            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;
            _context.SaveChanges();
            return dbExpense;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while editing the expense. {ex.Message}");
            }
        }

        public Expense GetExpense(int id)
        {
            try { 
           return _context.Expenses.First(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the expense. {ex.Message}");
            }
        }

        public List<Expense> GetExpenses()
        {
            try
            {
                return _context.Expenses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the expenses. {ex.Message}");
            }
        }
    }
}
