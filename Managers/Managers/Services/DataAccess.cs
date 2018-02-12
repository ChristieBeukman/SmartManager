using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Model;
using Managers.Model.ModelViews;
using GalaSoft.MvvmLight.Messaging;

namespace Managers.Services
{
    public class DataAccess : IDataAccess
    {
        ManagerEntities _Context;

        public DataAccess()
        {
            _Context = new ManagerEntities();
        }

        #region Accounts
        public void AddAccount(Account a)
        {
            _Context.Accounts.Add(a);
            _Context.SaveChanges();
        }

        public void DeleteAccount(Account a)
        {
            _Context.Entry(a).State = System.Data.Entity.EntityState.Deleted;
            _Context.SaveChanges();
        }

        public ObservableCollection<Account_AccountType> GetAccounts()
        {
            ObservableCollection<Account_AccountType> acc = new ObservableCollection<Account_AccountType>();

            var Query = (from a in _Context.Accounts
                         join t in _Context.AccountTypes
                         on a.AccountTypeId equals t.AccountTypeId
                         select new Account_AccountType
                         {
                             AccountTypeId = a.AccountTypeId,
                             AccountId = a.AccountId,
                             AccountNum = a.AccountNum,
                             Balance = a.Balance,
                             Bank = a.Bank,
                             CurrencyCountry = a.CurrencyCountry,
                             Name = a.Name,
                             TypeName = t.TypeName
                        }).ToList();
            foreach (var item in Query)
            {
                acc.Add(item);
            }

            return acc;
        }

        public ObservableCollection<Account> GetAccount()
        {
            ObservableCollection<Account> acc = new ObservableCollection<Account>();

            var Query =  from a in _Context.Accounts
                         select a;
                         
            foreach (var item in Query)
            {
                acc.Add(item);
            }

            return acc;
        }

        public void UpdateAccount(Account a)
        {
            _Context.Entry(a).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        #endregion

        #region AccountType
        public ObservableCollection<AccountType> GetAccountTypes()
        {
            ObservableCollection<AccountType> acc = new ObservableCollection<AccountType>();

            var Query = from a in _Context.AccountTypes
                        select a;
            foreach (var item in Query)
            {
                acc.Add(item);
            }

            return acc;
        }

        #endregion

        #region Expense

        public ObservableCollection<IncomeTransaction> GetIncomeTransactions(int accountId)
        {
            ObservableCollection<IncomeTransaction> inc = new ObservableCollection<IncomeTransaction>();

            var Query = from i in _Context.IncomeTransactions
                        where i.AccountId == accountId
                        select i;

            foreach (var item in Query)
            {
                inc.Add(item);
            }
            return inc;
        }

        public void DeleteExoenseTransaction(ExpenseTransaction i)
        {
            if (i != null)
            {
                _Context.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                _Context.SaveChanges();
            }
        }

        public ObservableCollection<ExpenseCategory> GetExpenseCategories()
        {
            ObservableCollection<ExpenseCategory> exp = new ObservableCollection<ExpenseCategory>();

            var Query = from i in _Context.ExpenseCategories
                        select i;

            foreach (var item in Query)
            {
                exp.Add(item);
            }
            return exp;
        }

        public void AddExpenseCategory(ExpenseCategory i)
        {
            _Context.ExpenseCategories.Add(i);
            _Context.SaveChanges();
        }

        public void UpdateExpenseCategory(ExpenseCategory i)
        {
            throw new NotImplementedException();
        }

        public void DeleteExpenseCategory(ExpenseCategory i)
        {
            throw new NotImplementedException();
        }

        public int AddExpenseTransaction(ExpenseTransaction i)
        {
            _Context.ExpenseTransactions.Add(i);
            _Context.SaveChanges();
            return i.ExpenseTransactionId;
        }

        #endregion

        #region Income

        public ObservableCollection<ExpenseTransaction> GetExpenseTransactions(int accountid)
        {
            ObservableCollection<ExpenseTransaction> inc = new ObservableCollection<ExpenseTransaction>();

            var Query = from i in _Context.ExpenseTransactions
                        where i.AccountId == accountid
                        select i;

            foreach (var item in Query)
            {
                inc.Add(item);
            }
            return inc;
        }

        public void DeleteIncomeTransaction(IncomeTransaction i)
        {
            if (i != null)
            {
                _Context.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                _Context.SaveChanges();
            }

        }

        public int AddIncome(IncomeTransaction i)
        {
            _Context.IncomeTransactions.Add(i);
            _Context.SaveChanges();
            return i.IncomeTransactionId;
        }

        public void UpdateIncome(IncomeTransaction i)
        {
            _Context.Entry(i).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }

        public ObservableCollection<IncomeCategory> GetIncomeCategories()
        {
            ObservableCollection<IncomeCategory> inc = new ObservableCollection<IncomeCategory>();
            var Query = from i in _Context.IncomeCategories
                        select i;
            foreach (var item in Query)
            {
                inc.Add(item);
            }
            return inc;
        }

        public void AddIncomeCategory(IncomeCategory i)
        {
            _Context.IncomeCategories.Add(i);
            _Context.SaveChanges();
        }

        public void UpdateCategory(IncomeCategory i)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(IncomeCategory i)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<PaymentType> GetPaymentTypes()
        {
            ObservableCollection<PaymentType> type = new ObservableCollection<PaymentType>();

            var Query = from p in _Context.PaymentTypes
                        select p;
            foreach (var item in Query)
            {
                type.Add(item);
            }
            return type;
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public void AddTransaction(Transaction i)
        {
            _Context.Transactions.Add(i);
            _Context.SaveChanges();
            
        }

        public void DeleteTransaction(Transaction i)
        {
            throw new NotImplementedException();
        }




        #endregion



    }
}
