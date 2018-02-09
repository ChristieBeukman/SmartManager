using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Messenger
{
    internal class GerericMessage<T>
    {
        private int id;
        private string s;

        public GerericMessage(int id)
        {
            this.id = id;
        }

        public GerericMessage(string s)
        {
            this.s = s;
        }

    }
}
