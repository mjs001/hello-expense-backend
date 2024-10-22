using System.ComponentModel.DataAnnotations;

namespace Expenses.DB
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description {  get; set; }
        public double Amount { get; set; }

    }
}
