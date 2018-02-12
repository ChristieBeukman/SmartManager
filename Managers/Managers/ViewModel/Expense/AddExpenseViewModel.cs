using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Managers.Model;
using Managers.Model.ModelViews;
using Managers.Services;
using Managers.Tools;
using Managers.Views.Expense;
using Managers.Services.Dialog;
using Managers.ViewModel.Expense;

namespace Managers.ViewModel.Expense
{
    public class AddExpenseViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;

        public AddExpenseViewModel()
        {
            _ServiceProxy = new DataAccess();
            toggle = new ToggleControl();

            MessengerInstance.Register<GenericMessage<string>>(this, ReceiveUpdateMessage);

            Accounts = new ObservableCollection<Model.Account>();
            SelectedAccount = new Model.Account();

            Categories = new ObservableCollection<ExpenseCategory>();
            SelectedCategory = new ExpenseCategory();

            PTypes = new ObservableCollection<PaymentType>();
            SelectedPaymentType = new PaymentType();

            GetAccounts();
            GetCategories();
            GetPaymentTypes();

            DisplayAddCategoryCommand = new ActionCommand(p => ExecuteDiaplayAddCategory());
        }

        #region Toggle
        ToggleControl toggle;

        private bool _ToggleAmount = true;
        private bool _ToggleDetails = true;

        public bool ToggleAmount
        {
            get
            {
                return _ToggleAmount;
            }

            set
            {
                _ToggleAmount = value;
                RaisePropertyChanged("ToggleAmount");
            }
        }

        public bool ToggleDetails
        {
            get
            {
                return _ToggleDetails;
            }

            set
            {
                _ToggleDetails = value;
                RaisePropertyChanged("ToggleDetails");
            }
        }

        public RelayCommand ToggleAmmountCommand { get; set; }
        public RelayCommand ToggleDetailsCommand { get; set; }

        void ExecuteToggleAmount()
        {
            ToggleAmount = toggle.ReadOnly(ToggleAmount);
            ToggleDetails = true;
        }

        void ExecuteToggleDetails()
        {
            ToggleDetails = toggle.ReadOnly(ToggleDetails);
            ToggleAmount = true;
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
            if (message == "GetExpenseCategories")
            {
                GetCategories();
            }
            if (message == "Save")
            {
                //SaveVisible = true;
                //DeleteVisible = false;
            }
        }

        #endregion

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

        #region Categories

        private ObservableCollection<ExpenseCategory> _Categories;
        private ExpenseCategory _SelectedCategory;

        public ObservableCollection<ExpenseCategory> Categories
        {
            get
            {
                return _Categories;
            }

            set
            {
                _Categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        public ExpenseCategory SelectedCategory
        {
            get
            {
                return _SelectedCategory;
            }

            set
            {
                _SelectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }


        void GetCategories()
        {
            Categories.Clear();
            foreach (var item in _ServiceProxy.GetExpenseCategories())
            {
                Categories.Add(item);
            }
        }

        #endregion

        #region PaymentTypes

        private ObservableCollection<PaymentType> _PTypes;
        private PaymentType _SelectedPaymentType;

        public ObservableCollection<PaymentType> PTypes
        {
            get
            {
                return _PTypes;
            }

            set
            {
                _PTypes = value;
                RaisePropertyChanged("PTypes");
            }
        }

        public PaymentType SelectedPaymentType
        {
            get
            {
                return _SelectedPaymentType;
            }

            set
            {
                _SelectedPaymentType = value;
                RaisePropertyChanged("SelectedPaymentType");
            }
        }

        void GetPaymentTypes()
        {
            PTypes.Clear();
            foreach (var item in _ServiceProxy.GetPaymentTypes())
            {
                PTypes.Add(item);
            }

        }

        #endregion

        public ICommand DisplayAddCategoryCommand { get; }

        private void ExecuteDiaplayAddCategory()
        {
            var viewModel = new AddExpenseCategoryViewModel();
            var view = new AddExpenseCategoryView { DataContext = viewModel };

            bool? result = view.ShowDialog();

            if (result.HasValue)
            {
                if (result.Value)
                {

                }
                else
                {
                    //Cancelled
                }
            }
        }

    }
}
