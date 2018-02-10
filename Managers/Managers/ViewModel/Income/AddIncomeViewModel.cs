using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Managers.Model;
using Managers.Model.ModelViews;
using Managers.Services;
using Managers.Tools;

namespace Managers.ViewModel.Income
{
    public class AddIncomeViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;

        public AddIncomeViewModel()
        {
            _ServiceProxy = new DataAccess();

            MessengerInstance.Register<GenericMessage<string>>(this, ReceiveUpdateMessage);

            Accounts = new ObservableCollection<Model.Account>();
            SelectedAccount = new Model.Account();

            Categories = new ObservableCollection<IncomeCategory>();
            SelectedCategory = new IncomeCategory();

            GetAccounts();
            GetCategories();
        }

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
                //DeleteVisible = true;
                //SaveVisible = false;
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

        private ObservableCollection<IncomeCategory> _Categories;
        private IncomeCategory _SelectedCategory;

        public ObservableCollection<IncomeCategory> Categories
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

        public IncomeCategory SelectedCategory
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
            foreach (var item in _ServiceProxy.GetIncomeCategories())
            {
                Categories.Add(item);
            }
        }

        #endregion



    }
}
