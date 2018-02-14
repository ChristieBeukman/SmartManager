using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Model.ModelViews
{
    public class TransactionViews
    {
        public int TransactionId { get; set; }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public string AccountNum { get; set; }
        public decimal Balance { get; set; }
        public int AccountTypeId { get; set; }
        public string CurrencyCountry { get; set; }
        public int TransactionType { get; set; }

        
        public Nullable<int> IncomeTransactionId { get; set; }
        public System.DateTime IncomeDate { get; set; }
        public string IncomeDetails { get; set; }
        public decimal IncomeAmount { get; set; }
        public int IncPaymentTypeId { get; set; }
        public int IncomeCategoryId { get; set; }

        public Nullable<int> ExpenseTransactionId { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public string ExpenseDetails { get; set; }
        public decimal ExpenseAmount { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int ExpensePaymentTypeId { get; set; }
    }
}
