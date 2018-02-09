using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Model.ModelViews
{
    public class Account_AccountType
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public string AccountNum { get; set; }
        public decimal Balance { get; set; }
        public int AccountTypeId { get; set; }
        public string CurrencyCountry { get; set; }
        public string TypeName { get; set; }
    }
}
