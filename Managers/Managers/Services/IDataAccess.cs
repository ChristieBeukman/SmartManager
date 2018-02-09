using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Managers.Model;

namespace Managers.Services
{
    public interface IDataAccess
    {
        ObservableCollection<AccountType> GetAccountTypes();

        void AddAccount(Account a);
        void UpdateAccount(Account a);
        void DeleteAccount(Account a);
        ObservableCollection<Account> GetAccounts();

    }
}
