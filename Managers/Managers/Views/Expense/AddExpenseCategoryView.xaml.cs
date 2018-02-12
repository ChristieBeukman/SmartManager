using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Managers.Services.Dialog;

namespace Managers.Views.Expense
{
    /// <summary>
    /// Interaction logic for AddExpenseCategoryView.xaml
    /// </summary>
    public partial class AddExpenseCategoryView : Window ,IDialog
    {
        public AddExpenseCategoryView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Add Another Category>", "Added", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    break;
                case MessageBoxResult.No:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
