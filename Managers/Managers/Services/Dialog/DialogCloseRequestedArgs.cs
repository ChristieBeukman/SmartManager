using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Services.Dialog
{
    public class DialogCloseRequestedArgs : EventArgs
    {
        public DialogCloseRequestedArgs(bool? dialogResult)
        {
            DialogResult = dialogResult;
        }


        public bool? DialogResult { get; }
    }
}
