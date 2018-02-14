using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using Managers.ViewModel.Account;
using Managers.ViewModel.Income;
using Managers.ViewModel.Expense;
using Managers.ViewModel.Balance;

namespace Managers.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _CurrentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }

            set
            {
                _CurrentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        #region Account
        private static readonly AccountManagementViewModel accountManagementViewModel = new AccountManagementViewModel();

        public RelayCommand ViewAccountManagementCommand { get; set; }

        void ExecuteViewAccountManagement()
        {
            CurrentViewModel = MainViewModel.accountManagementViewModel;
            NewObject("AccountManagement");
        }

        #endregion

        #region AddIncome
        private static readonly AddIncomeViewModel addIncomeViewModel = new AddIncomeViewModel();
        public RelayCommand ViewAddIncomeCommand { get; set; }

        void ExecuteViewAddIncome()
        {
            CurrentViewModel = MainViewModel.addIncomeViewModel;
            NewObject("AddIncome");
        }
        #endregion

        #region editIncome
        private static readonly EditIncomeViewModel editIncomeViewModel= new EditIncomeViewModel();
        public RelayCommand ViewEditIncomeCommand { get; set; }

        void ExecuteViewEditIncome()
        {
            CurrentViewModel = MainViewModel.editIncomeViewModel;
        }

        #endregion

        #region AddExpense
        private static readonly AddExpenseViewModel addExpenseViewModel = new AddExpenseViewModel();
        public RelayCommand ViewAddExpenseCommand { get; set; }

        void ExecutViewAddExpense()
        {
            CurrentViewModel = MainViewModel.addExpenseViewModel;
        }

        #endregion

        #region Balance
        private static readonly BalanceViewModel balanceViewModel= new BalanceViewModel();
        public RelayCommand ViewBalanceCommand { get; set; }

        void ExecuteViewBalance()
        {
            CurrentViewModel = MainViewModel.balanceViewModel;
        }

        #endregion

        #region Nessenger

        void NewObject(string i)
        {
            MessengerInstance.Send<GenericMessage<string>>(new GenericMessage<string>(i));
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ViewAccountManagementCommand = new RelayCommand(ExecuteViewAccountManagement);
            ViewAddIncomeCommand = new RelayCommand(ExecuteViewAddIncome);
            ViewEditIncomeCommand = new RelayCommand(ExecuteViewEditIncome);
            ViewAddExpenseCommand = new RelayCommand(ExecutViewAddExpense);
            ViewBalanceCommand = new RelayCommand(ExecuteViewBalance);

        }
    }
}