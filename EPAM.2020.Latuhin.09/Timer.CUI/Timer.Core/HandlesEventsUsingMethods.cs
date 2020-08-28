using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Core
{
    class HandlesEventsUsingMethods : ICutDownNotifier
    {
        public Timer timer;

        public delegate void StartTimeTask(string nameTask, string timeAllotted);
        public Action<string, string> timeComplete;

        public HandlesEventsUsingMethods(string name)
        {
            timer = new Timer(name);
        }

        public void Init()
        {
            timer.NotifyStartCountdown += StartCountdown;
            timer.NotifyCountdownLeft += CountdownLeft;
            timer.NotifyStopCountdown += StopCountdown;
        }

        public void Run()
        {

        }

        public void StartCountdown(object sender, TimerEventArgs e)
        {


            Console.WriteLine($"Name of timer {timer.Name}");
        }

        public void CountdownLeft(int timeLeft)
        {
            Console.WriteLine($"Name of timer {timer.Name}");
            Console.WriteLine($"Left seconds {timeLeft}");
        }

        public void StopCountdown(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Name of timer {timer.Name}");
        }
    }
}
