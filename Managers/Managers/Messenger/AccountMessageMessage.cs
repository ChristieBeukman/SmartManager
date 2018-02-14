using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Model;

namespace Managers.Messenger
{
    public class AccountMessage : MessageBase
    {
        public Account SelectedAccount { get; set; }

        public AccountMessage(Account selectedAccount)
        {
            SelectedAccount = selectedAccount;
        }
    }
}
