using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Managers.ViewModel.Account;

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

        #region CurrentViewModel
        private static readonly AccountManagementViewModel accountManagementViewModel = new AccountManagementViewModel();

        public RelayCommand ViewAccountManagementCommand { get; set; }

        void ExecuteViewAccountManagement()
        {
            CurrentViewModel = MainViewModel.accountManagementViewModel;
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ViewAccountManagementCommand = new RelayCommand(ExecuteViewAccountManagement);
        }
    }
}