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

namespace Managers.ViewModel.Account
{
    public class AddAccountViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;

        public AddAccountViewModel()
        {
            _ServiceProxy = new DataAccess();
            toggle = new ToggleControl();
            ToggleAccountNameCommand = new RelayCommand(ExecuteToggleAccountName);
            ToggleAccNumCommand = new RelayCommand(ExecuteToggleAccNum);
            ToggleBankCommand = new RelayCommand(ExecuteToggleNBank);
            ToggleBalanceCommand = new RelayCommand(ExecuteToggleBalance);

            Countries = new ObservableCollection<DDLStructure>();
            SelectedCountry = new DDLStructure();
            GetCountries();

            AccountTypes = new ObservableCollection<AccountType>();
            SelectedAccountType = new AccountType();
            GetAccountTypes();

            account = new Model.Account();

            AddAccountCommand = new RelayCommand(ExecuteAddAccount);
        }

        #region Toggle

        ToggleControl toggle;
        private bool _AccountNameReadOnly = true;
        private bool _BankNameReadOnly = true;
        private bool _AccNumReadOnly = true;
        private bool _BalanceReadOnly = true;


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

        public RelayCommand ToggleAccountNameCommand { get; set; }
        public RelayCommand ToggleBankCommand { get; set; }
        public RelayCommand ToggleAccNumCommand { get; set; }
        public RelayCommand ToggleBalanceCommand { get; set; }

        void ExecuteToggleAccountName()
        {
            AccountNameReadOnly = toggle.ReadOnly(AccountNameReadOnly);
            BankNameReadOnly = true;
            AccNumReadOnly = true;
            BalanceReadOnly = true;
        }

        void ExecuteToggleBalance()
        {
            BalanceReadOnly = toggle.ReadOnly(BalanceReadOnly);
            AccountNameReadOnly = true;
            BankNameReadOnly = true;
            AccNumReadOnly = true;

        }

        void ExecuteToggleNBank()
        {
            BankNameReadOnly = toggle.ReadOnly(BankNameReadOnly);
            BalanceReadOnly = true;
            AccountNameReadOnly = true;
            AccNumReadOnly = true;
        }

        void ExecuteToggleAccNum()
        {
            AccNumReadOnly = toggle.ReadOnly(AccNumReadOnly);
            BalanceReadOnly = true;
            BankNameReadOnly = true;
            AccountNameReadOnly = true;
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


        #region Account

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

        public RelayCommand AddAccountCommand { get; set; }

        void ExecuteAddAccount()
        {
            var result = MessageBox.Show("Add Account?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question);

            switch (result)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    account.AccountTypeId = SelectedAccountType.AccountTypeId;
                    account.CurrencyCountry = SelectedCountry.Name;
                    _ServiceProxy.AddAccount(account);
                    GetAccountTypes();
                    GetCountries();
                    account.AccountNum = string.Empty;
                    account.Balance = 0;
                    account.Bank = string.Empty;
                    account.Name = string.Empty;
                    account.CurrencyCountry = string.Empty;
                    MessageBox.Show("Saved");
                    SendUpdateMessage("GetAccounts");
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Messages

        void SendUpdateMessage(string message)
        {
            MessengerInstance.Send<GenericMessage<string>>(new GenericMessage<string>(message));
        }

        #endregion

    }
}
