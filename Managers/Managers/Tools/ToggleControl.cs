using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Tools
{
    public class ToggleControl
    {
        public bool ReadOnly(bool b)
        {
            if (b == false)
            {
                b = true;
            }
            else if (b == true)
            {
                b = false;
            }
            return b;
        }
    }
}
