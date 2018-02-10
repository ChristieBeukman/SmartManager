using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Model.ModelViews
{
    public class Income_Accounts_Category
    {
        public int IncomeTransactionId { get; set; }
        public System.DateTime Date { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public string AccountNum { get; set; }
        public decimal Balance { get; set; }

        public int IncomeCategoryId { get; set; }
        public string CategoryTypeName { get; set; }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
    }
}
