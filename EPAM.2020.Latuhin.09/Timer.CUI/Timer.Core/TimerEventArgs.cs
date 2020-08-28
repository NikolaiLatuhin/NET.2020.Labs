using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Core
{
    public class TimerEventArgs : EventArgs
    {
        public string Message { get; }
        public int Time { get; }

        public TimerEventArgs(string message, int elapsedTimer)
        {
            Message = message;
            Time = elapsedTimer;
        }
    }
}
