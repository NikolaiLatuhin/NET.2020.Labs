using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer.Core;

namespace Timer.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Core.Timer("Test");
            timer.NotifyStartCountdown += DisplayResult;
            timer.NotifyCountdownLeft += DisplayElapsedTime;

            timer.Start("Message test", 5);
        }

        private static void DisplayResult(object sender, TimerEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void DisplayElapsedTime(int elapsedSeconds)
        {
            Console.WriteLine("Seconds last: " + elapsedSeconds);
        }
    }
}
