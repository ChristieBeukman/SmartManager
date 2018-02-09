using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using Managers.Model;
using Managers.Services;
using Managers.Tools;
using Managers.Model.ModelViews;

namespace Managers.ViewModel.Account
{
    public class EditAccountViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;

        public EditAccountViewModel()
        {
            _ServiceProxy = new DataAccess();

            toggle = new ToggleControl();
            ToggleAccountNameCommand = new RelayCommand(ExecuteToggleAccountName);
            ToggleAccNumCommand = new RelayCommand(ExecuteToggleAccNum);
            ToggleBankCommand = new RelayCommand(ExecuteToggleNBank);
            ToggleBalanceCommand = new RelayCommand(ExecuteToggleBalance);
            ToggleAccountTypeCommand = new RelayCommand(ExecuteToggleAccountType);
            ToggleCurrencyCommand = new RelayCommand(ExecuteToggleCurrency);

            Countries = new ObservableCollection<DDLStructure>();
            SelectedCountry = new DDLStructure();
            GetCountries();

            AccountTypes = new ObservableCollection<AccountType>();
            SelectedAccountType = new AccountType();
            GetAccountTypes();

            Accounts = new ObservableCollection<Account_AccountType>();
            SelectedAccount = new Account_AccountType();
            GetAccounts();
            UpdateAccountCommand = new RelayCommand(ExecuteUpdateAccount);
            DeleteAccountCommand = new RelayCommand(ExecuteDeleteCommand);
            account = new Model.Account();

            MessengerInstance.Register<GenericMessage<string>>(this, ReceiveUpdateMessage);

            
        }

        #region Toggle

        ToggleControl toggle;
        private bool _AccountNameReadOnly = true;
        private bool _BankNameReadOnly = true;
        private bool _AccNumReadOnly = true;
        private bool _BalanceReadOnly = true;
        private bool _AccountTypeInvisible = false;
        private bool _AccountTypeVisible = true;
        private bool _CurrencyInvisible = false;
        private bool _CurrencyVisible = true;
        private bool _SaveVisible = false;
        private bool _DeleteVisible= false;

        public bool AccountNameReadOnly
        {
            get
            {
                return _AccountNameReadOnly;
            }

            set
            {
                _AccountNameReadOnly = value;
                RaisePropertyChanged("AccountNameReadOnly");
            }
        }

        public bool BankNameReadOnly
        {
            get
            {
                return _BankNameReadOnly;
            }

            set
            {
                _BankNameReadOnly = value;
                RaisePropertyChanged("BankNameReadOnly");
            }
        }

        public bool AccNumReadOnly
        {
            get
            {
                return _AccNumReadOnly;
            }

            set
            {
                _AccNumReadOnly = value;
                RaisePropertyChanged("AccNumReadOnly");
            }
        }

        public bool BalanceReadOnly
        {
            get
            {
                return _BalanceReadOnly;
            }

            set
            {
                _BalanceReadOnly = value;
                RaisePropertyChanged("BalanceReadOnly");
            }
        }

        public bool AccountTypeVisible
        {
            get
            {
                return _AccountTypeVisible;
            }

            set
            {
                _AccountTypeVisible = value;
                RaisePropertyChanged("AccountTypeVisible");
            }
        }

        public bool AccountTypeInvisible
        {
            get
            {
                return _AccountTypeInvisible;
            }

            set
            {
                _AccountTypeInvisible = value;
                RaisePropertyChanged("AccountTypeInvisible");
            }
        }

        public bool CurrencyInvisible
        {
            get
            {
                return _CurrencyInvisible;
            }

            set
            {
                _CurrencyInvisible = value;
                RaisePropertyChanged("CurrencyInvisible");
            }
        }

        public bool CurrencyVisible
        {
            get
            {
                return _CurrencyVisible;
            }

            set
            {
                _CurrencyVisible = value;
                RaisePropertyChanged("CurrencyVisible");
            }
        }

        public bool SaveVisible
        {
            get
            {
                return _SaveVisible;
            }

            set
            {
                _SaveVisible = value;
                RaisePropertyChanged("SaveVisible");
            }
        }

        public bool DeleteVisible
        {
            get
            {
                return _DeleteVisible;
            }

            set
            {
                _DeleteVisible = value;
                RaisePropertyChanged("DeleteVisible");
            }
        }

        public RelayCommand ToggleAccountNameCommand { get; set; }
        public RelayCommand ToggleBankCommand { get; set; }
        public RelayCommand ToggleAccNumCommand { get; set; }
        public RelayCommand ToggleBalanceCommand { get; set; }
        public RelayCommand ToggleAccountTypeCommand { get; set; }
        public RelayCommand ToggleCurrencyCommand { get; set; }

        void ExecuteToggleAccountName()
        {
            AccountNameReadOnly = toggle.ReadOnly(AccountNameReadOnly);
            BankNameReadOnly = true;
            AccNumReadOnly = true;
            BalanceReadOnly = true;
            AccountTypeVisible = true;
            AccountTypeInvisible = false;
            CurrencyVisible = true;
            CurrencyInvisible = false;
        }

        void ExecuteToggleBalance()
        {
            BalanceReadOnly = toggle.ReadOnly(BalanceReadOnly);
            AccountNameReadOnly = true;
            BankNameReadOnly = true;
            AccNumReadOnly = true;
            AccountTypeVisible = true;
            AccountTypeInvisible = false;
            CurrencyVisible = true;
            CurrencyInvisible = false;

        }

        void ExecuteToggleNBank()
        {
            BankNameReadOnly = toggle.ReadOnly(BankNameReadOnly);
            BalanceReadOnly = true;
            AccountNameReadOnly = true;
            AccNumReadOnly = true;
            AccountTypeVisible = true;
            AccountTypeInvisible = false;
            CurrencyVisible = true;
            CurrencyInvisible = false;
        }

        void ExecuteToggleAccNum()
        {
            AccNumReadOnly = toggle.ReadOnly(AccNumReadOnly);
            BalanceReadOnly = true;
            BankNameReadOnly = true;
            AccountNameReadOnly = true;
            AccountTypeVisible = true;
            AccountTypeInvisible = false;
            CurrencyVisible = true;
            CurrencyInvisible = false;
        }

        void ExecuteToggleAccountType()
        {
            AccountTypeVisible = toggle.ReadOnly(AccountTypeVisible);
            AccountTypeInvisible = toggle.ReadOnly(AccountTypeVisible);
            AccNumReadOnly = true;
            BalanceReadOnly = true;
            BankNameReadOnly = true;
            AccountNameReadOnly = true;
            CurrencyVisible = true;
            CurrencyInvisible = false;
            if (SelectedAccountType != null)
            {
                SelectedAccount.AccountTypeId = SelectedAccountType.AccountTypeId;
                SelectedAccount.TypeName = SelectedAccountType.TypeName;
            }
            
            RaisePropertyChanged("SelectedAccount");
        }

        void ExecuteToggleCurrency()
        {
            CurrencyVisible = toggle.ReadOnly(CurrencyVisible);
            CurrencyInvisible = toggle.ReadOnly(CurrencyInvisible);
            AccNumReadOnly = true;
            BalanceReadOnly = true;
            BankNameReadOnly = true;
            AccountNameReadOnly = true;
            AccountTypeVisible = true;
            AccountTypeInvisible = false;
            SelectedAccount.CurrencyCountry = SelectedCountry.Name;
            RaisePropertyChanged("SelectedAccount");

        }

        #endregion

        #region Countries
        private ObservableCollection<DDLStructure> _Countries;
        private DDLStructure _SelectedCountry;

        public ObservableCollection<DDLStructure> Countries
        {
            get
            {
                return _Countries;
            }

            set
            {
                _Countries = value;
                RaisePropertyChanged("Countries");
            }
        }

        public DDLStructure SelectedCountry
        {
            get
            {
                return _SelectedCountry;
            }

            set
            {
                _SelectedCountry = value;
                RaisePropertyChanged("SelectedCountry");
            }
        }


        public struct DDLStructure
        {
            public String Symbol { get; set; }

            public String Name { get; set; }

        }

        private void GetCountries()
        {
            Countries.Clear();
            var region = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                          .Select(x => new RegionInfo(x.LCID));

            var countries = (from x in region
                             select new DDLStructure() { Symbol = x.CurrencySymbol, Name = x.EnglishName })
                         .Distinct()
                         .OrderBy(x => x.Name)
                         .ToList<DDLStructure>();
            foreach (var item in countries)
            {
                Countries.Add(item);
            }
        }

        #endregion
        
        #region AccountType
        private ObservableCollection<AccountType> _AccountTypes;
        private AccountType _SelectedAccountType;

        public ObservableCollection<AccountType> AccountTypes
        {
            get
            {
                return _AccountTypes;
            }

            set
            {
                _AccountTypes = value;
                RaisePropertyChanged("AccountTypes");
            }
        }

        public AccountType SelectedAccountType
        {
            get
            {
                return _SelectedAccountType;
            }

            set
            {
                _SelectedAccountType = value;
                RaisePropertyChanged("SelectedAccountType");
            }
        }


        void GetAccountTypes()
        {
            AccountTypes.Clear();
            foreach (var item in _ServiceProxy.GetAccountTypes())
            {
                AccountTypes.Add(item);
            }
        }

        #endregion

        #region Accoutns

        private ObservableCollection<Account_AccountType> _Accounts;
        private Account_AccountType _SelectedAccount;
        private Model.Account _account;

        public Model.Account account
        {
            get
            {
                return _account;
            }

            set
            {
                _account = value;
                RaisePropertyChanged("account");
            }
        }


        public ObservableCollection<Account_AccountType> Accounts
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

        public Account_AccountType SelectedAccount
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
            foreach (var item in _ServiceProxy.GetAccounts())
            {
                Accounts.Add(item);
            }
        }

        #endregion

        #region Update

        public RelayCommand UpdateAccountCommand { get; set; }

        void ExecuteUpdateAccount()
        {
            var result = MessageBox.Show("Save changes?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    MoveView();
                    _ServiceProxy.UpdateAccount(account);
                    GetAccounts();
                    MessageBox.Show("Updated");
                    break;
                case MessageBoxResult.No:
                    GetAccounts();
                    GetAccountTypes();
                    GetCountries();
                    break;
                default:
                    break;
            }
        }

        void MoveView()
        {
            account.AccountId = SelectedAccount.AccountId;
            account.Name = SelectedAccount.Name;
            account.Bank = SelectedAccount.Bank;
            account.AccountNum = SelectedAccount.AccountNum;
            account.Balance = SelectedAccount.Balance;
            account.AccountTypeId = SelectedAccount.AccountTypeId;
            account.CurrencyCountry = SelectedAccount.CurrencyCountry;
        }

        #endregion

        #region Messaging

        void ReceiveUpdateMessage(GenericMessage<string> genericMessage)
        {
            string message = genericMessage.Content;
            if (message == "GetAccounts")
            {
                GetAccounts();
            }
            if (message == "Delete")
            {
                DeleteVisible = true;
                SaveVisible = false;
            }
            if (message == "Save")
            {
                SaveVisible = true;
                DeleteVisible = false;
            }
        }

        #endregion

        #region Delete

        private ObservableCollection<IncomeTransaction> _IncomeTransactions;

        public ObservableCollection<IncomeTransaction> IncomeTransactions
        {
            get
            {
                return _IncomeTransactions;
            }

            set
            {
                _IncomeTransactions = value;
                RaisePropertyChanged("IncomeTransactions");
            }
        }

        public RelayCommand DeleteAccountCommand { get; set; }

        void ExecuteDeleteCommand()
        {
            var result = MessageBox.Show("Delete Account and all transactions for the account?", "DELETE", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            switch (result)
            {
                case MessageBoxResult.OK:
                    foreach (var item in _ServiceProxy.GetIncomeTransactions(SelectedAccount.AccountId))
                    {
                        _ServiceProxy.DeleteIncomeTransaction(item);
                    }
                    foreach (var item in _ServiceProxy.GetExpenseTransactions(SelectedAccount.AccountId))
                    {
                        _ServiceProxy.DeleteExoenseTransaction(item);
                    }
                    MoveView();

                    _ServiceProxy.DeleteAccount(account);
                    MessageBox.Show("Deleted Account");
                    GetAccounts();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        #endregion

    }
}
