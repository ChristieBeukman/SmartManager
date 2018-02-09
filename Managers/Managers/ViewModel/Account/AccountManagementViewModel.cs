using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Managers.ViewModel.Account
{
    public class AccountManagementViewModel : ViewModelBase
    {
        public AccountManagementViewModel()
        {
            ViewEditAccountCommand = new RelayCommand(ExecuteViewEditAccount);
            ViewAddAccountCommand = new RelayCommand(ExecuteViewAddAccount);
            DeleteViewCommnd = new RelayCommand(ExecuteDeleteViewCommand);


        }

        #region CurrentViewModel
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

        #endregion

        #region Edit

        private static readonly EditAccountViewModel editAccountViewModel = new EditAccountViewModel();

        public RelayCommand ViewEditAccountCommand { get; set; }

        private void ExecuteViewEditAccount()
        {


            VisibleEditControl = true;
            VisibleDeleteControl = true;
            GridRow = 3;
            SendUpdateMessage("Save");
            CurrentViewModel = AccountManagementViewModel.editAccountViewModel;
        }

        #endregion

        #region add

        private static readonly AddAccountViewModel addAccountViewModel = new AddAccountViewModel();

        public RelayCommand ViewAddAccountCommand { get; set; }

        private void ExecuteViewAddAccount()
        {
            VisibleDeleteControl = false;
            VisibleEditControl = false;
            CurrentViewModel = AccountManagementViewModel.addAccountViewModel;
        }

        #endregion

        private bool _VisibleEditControl = false;
        private bool _VisibleDeleteControl = false;
        private int _GridRow;

        public bool VisibleEditControl
        {
            get
            {
                return _VisibleEditControl;
            }

            set
            {
                _VisibleEditControl = value;
                RaisePropertyChanged("VisibleEditControl");
            }
        }

        public bool VisibleDeleteControl
        {
            get
            {
                return _VisibleDeleteControl;
            }

            set
            {
                _VisibleDeleteControl = value;
                RaisePropertyChanged("VisibleDeleteControl");
            }
        }


        public int GridRow
        {
            get
            {
                return _GridRow;
            }

            set
            {
                _GridRow = value;
                RaisePropertyChanged("GridRow");
            }
        }

        public RelayCommand DeleteViewCommnd { get; set; }

        void ExecuteDeleteViewCommand()
        {

            VisibleEditControl = true;
            VisibleDeleteControl = true;
            GridRow = 5;
            SendUpdateMessage("Delete");
            CurrentViewModel = AccountManagementViewModel.editAccountViewModel;

        }


        #region Messages

        void SendUpdateMessage(string message)
        {
            MessengerInstance.Send<GenericMessage<string>>(new GenericMessage<string>(message));
        }

        #endregion

    }
}
