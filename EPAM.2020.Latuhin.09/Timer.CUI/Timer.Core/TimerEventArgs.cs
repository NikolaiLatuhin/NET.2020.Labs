using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Core
{
    public class TimerEventArgs : EventArgs
    {
        public string Name { get; }
        public int TimeSeconds { get; }
        public string Message { get; }

        public TimerEventArgs(string name, int timeSecondsLeft, string message = "")
        {
            Name = name;
            TimeSeconds = timeSecondsLeft;
            Message = message;
        }
    }
}
