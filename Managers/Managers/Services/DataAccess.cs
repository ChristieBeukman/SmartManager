using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Model;
using Managers.Model.ModelViews;

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

        public void AddIncome(IncomeTransaction i)
        {
            _Context.IncomeTransactions.Add(i);
            _Context.SaveChanges();
        }

        public void UpdateIncome(IncomeTransaction i)
        {
            _Context.Entry(i).State = System.Data.Entity.EntityState.Modified;
            _Context.SaveChanges();
        }
        #endregion



    }
}
