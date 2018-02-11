using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Services.Dialog
{
    public interface IDailogService
    {
        void Register<TViewModel, TView>() where TViewModel : IDailogRequestClose
                                           where TView : IDialog;
        bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDailogRequestClose;
    }
}
