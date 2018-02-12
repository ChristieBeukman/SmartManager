using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Managers.Services;
using Managers.Model;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Managers.ViewModel.Expense
{
    public class AddExpenseCategoryViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;
        public AddExpenseCategoryViewModel()
        {
            _ServiceProxy = new DataAccess();
            ExpCategory = new ExpenseCategory();

            AddExpenseCategoryCommand = new RelayCommand(ExecuteExpenseCategoryCommand);

        }

        private ExpenseCategory _ExpCategory;

        public ExpenseCategory ExpCategory
        {
            get
            {
                return _ExpCategory;
            }

            set
            {
                _ExpCategory = value;
                RaisePropertyChanged("ExpCategory");
            }
        }

        public RelayCommand AddExpenseCategoryCommand { get; set; }

        void ExecuteExpenseCategoryCommand()
        {
            _ServiceProxy.AddExpenseCategory(ExpCategory);
            MessageBox.Show("Added");
            SendUpdateMessage("GetExpenseCategories");
        }

        public void SendUpdateMessage(string i)
        {
            MessengerInstance.Send<GenericMessage<string>>(new GenericMessage<string>(i));
        }

    }
}
