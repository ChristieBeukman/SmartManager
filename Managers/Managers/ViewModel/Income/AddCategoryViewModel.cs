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

namespace Managers.ViewModel.Income
{
    public class AddCategoryViewModel : ViewModelBase
    {
        IDataAccess _ServiceProxy;
        public AddCategoryViewModel()
        {
            _ServiceProxy = new DataAccess();
            IncCategory = new IncomeCategory();
            AddIncomeCategory = new RelayCommand(ExecuteAddIncomeCategory);
        }

        private IncomeCategory _incCategory;

        public IncomeCategory IncCategory
        {
            get
            {
                return _incCategory;
            }

            set
            {
                _incCategory = value;
                RaisePropertyChanged("IncCategory");
            }

        }

        public RelayCommand AddIncomeCategory { get; set; }

        void ExecuteAddIncomeCategory()
        {
            _ServiceProxy.AddIncomeCategory(IncCategory);
            MessageBox.Show("Added");
            SendUpdateMessage("GetIncomeCategories");
        }

        public void SendUpdateMessage(string i)
        {
            MessengerInstance.Send<GenericMessage<string>>(new GenericMessage<string>(i));
        }

    }
}
