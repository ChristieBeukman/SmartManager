using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Managers.Model;
using Managers.Model.ModelViews;

namespace Managers.Services
{
    public interface IDataAccess
    {
        ObservableCollection<AccountType> GetAccountTypes();
        //Accounts
        void AddAccount(Account a);
        void UpdateAccount(Account a);
        void DeleteAccount(Account a);
        ObservableCollection<Account_AccountType> GetAccounts();
        ObservableCollection<Account> GetAccount();

        //Income
        ObservableCollection<IncomeTransaction> GetIncomeTransactions(int accountId);
        void AddIncome(IncomeTransaction i);
        void UpdateIncome(IncomeTransaction i);
        void DeleteIncomeTransaction(IncomeTransaction i);

        //IncomeCategory
        ObservableCollection<IncomeCategory> GetIncomeCategories();
        void AddIncomeCategory(IncomeCategory i);
        void UpdateCategory(IncomeCategory i);
        void DeleteCategory(IncomeCategory i);

        //Payment Type
        ObservableCollection<PaymentType> GetPaymentTypes();
        //Expense
        ObservableCollection<ExpenseTransaction> GetExpenseTransactions(int accountid);
        void DeleteExoenseTransaction(ExpenseTransaction i);
        //ExpenseCategory
        ObservableCollection<ExpenseCategory> GetExpenseCategories();
        void AddExpenseCategory(ExpenseCategory i);
        void UpdateExpenseCategory(ExpenseCategory i);
        void DeleteExpenseCategory(ExpenseCategory i);
    }
}
