

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Managers.ViewModel.Account;

namespace Managers.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);



            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AccountManagementViewModel>();
            SimpleIoc.Default.Register<EditAccountViewModel>();
            SimpleIoc.Default.Register<AddAccountViewModel>();

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AccountManagementViewModel accountManagementViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccountManagementViewModel>();
            }
        }

        public EditAccountViewModel editAccountViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditAccountViewModel>();
            }
        }

        public AddAccountViewModel addAccountViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddAccountViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}