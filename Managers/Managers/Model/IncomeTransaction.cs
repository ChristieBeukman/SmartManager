//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Managers.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class IncomeTransaction
    {
        public int IncomeTransactionId { get; set; }
        public System.DateTime Date { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int PaymentTypeId { get; set; }
        public int IncomeCategoryId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual IncomeCategory IncomeCategory { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
