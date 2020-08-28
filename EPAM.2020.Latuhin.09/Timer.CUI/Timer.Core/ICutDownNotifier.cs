using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Core
{
    interface ICutDownNotifier
    {
        void Init();
        void Run();
    }
}
