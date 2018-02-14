using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Managers.Messenger;
using Managers.Services;
using Managers.Model;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Managers.Model.ModelViews;
using System.Collections.ObjectModel;

namespace Managers.ViewModel.Balance
{
    public class BalanceViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;

        public BalanceViewModel()
        {
            _ServiceProxy = new DataAccess();

            Accounts = new ObservableCollection<Model.Account>();
            SelectedAccount = new Model.Account();
            AccTransactions = new ObservableCollection<TransactionViews>();

            GetAccounts();
            BalanceViewCommand = new RelayCommand(ExecuteBalanceView);
            MessengerInstance.Register<AccountMessage>(this, msg =>
             {
                 SelectedAccount = msg.SelectedAccount;
             });
        }

        #region Accounts

        private ObservableCollection<Model.Account> _Accounts;
        private Model.Account _SelectedAccount;

        public ObservableCollection<Model.Account> Accounts
        {
            get
            {
                return _Accounts;
            }

            set
            {
                _Accounts = value;
                RaisePropertyChanged("Accounts");
            }
        }

        public Model.Account SelectedAccount
        {
            get
            {
                return _SelectedAccount;
            }

            set
            {
                _SelectedAccount = value;
                RaisePropertyChanged("SelectedAccount");
            }
        }


        void GetAccounts()
        {
            Accounts.Clear();
            foreach (var item in _ServiceProxy.GetAccount())
            {
                Accounts.Add(item);
            }
        }


        #endregion

        #region Balane

        private ObservableCollection<TransactionViews> _AccTransactions;
        private bool _IncomeFilter = true;
        private bool _ExpenseFilter = true;

        public ObservableCollection<TransactionViews> AccTransactions
        {
            get
            {
                return _AccTransactions;
            }

            set
            {
                _AccTransactions = value;
                RaisePropertyChanged("AccTransactions");
            }
        }

        public bool IncomeFilter
        {
            get
            {
                return _IncomeFilter;
            }

            set
            {
                _IncomeFilter = value;
                RaisePropertyChanged("IncomeFilter");
            }
        }

        public bool ExpenseFilter
        {
            get
            {
                return _ExpenseFilter;
            }

            set
            {
                _ExpenseFilter = value;
                RaisePropertyChanged("ExpenseFilter");
            }
        }

        public RelayCommand BalanceViewCommand { get; set; }

        void ExecuteBalanceView()
        {
            AccTransactions.Clear();
            foreach (var item in _ServiceProxy.GetTransactions(SelectedAccount.AccountId,IncomeFilter,ExpenseFilter))
            {
                AccTransactions.Add(item);
            }
        }

        #endregion

    }
}
