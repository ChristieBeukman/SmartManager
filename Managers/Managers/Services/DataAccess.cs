using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Model;

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
            throw new NotImplementedException();
        }

        public ObservableCollection<Account> GetAccounts()
        {
            ObservableCollection<Account> acc = new ObservableCollection<Account>();

            var Query = from a in _Context.Accounts
                        select a;
            foreach (var item in Query)
            {
                acc.Add(item);
            }

            return acc;
        }

        public void UpdateAccount(Account a)
        {
            throw new NotImplementedException();
        }

        #endregion

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

    }
}
