using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Services.Dialog
{
    public interface IDailogRequestClose
    {
        event EventHandler<DialogCloseRequestedArgs> CloseRequested;
    }
}
