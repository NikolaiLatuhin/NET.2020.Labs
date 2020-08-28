using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer.Core
{
    public class Timer
    {
        public string Name { get; set; }

        public delegate void StartCountdownHandler(object sender, TimerEventArgs e);
        public delegate void CountdownLeftHandler(int countdown);
        public delegate void StopCountdownHandler(object sender, TimerEventArgs e);

        public event StartCountdownHandler NotifyStartCountdown;
        public event CountdownLeftHandler NotifyCountdownLeft;
        public event StopCountdownHandler NotifyStopCountdown;

        public Timer(string name)
        {
            Name = name;
        }


        public void Start(string message, int timeLeft)
        {
            NotifyStartCountdown?.Invoke(this, new TimerEventArgs(message, timeLeft));

            while (timeLeft > 0)
            {
                // Передаем подписавшемуся на событие типу, сколько секунд осталось.
                NotifyCountdownLeft?.Invoke(timeLeft);
                // Одна секунда равна 1000 миллисекундам
                const int oneSecond = 1000;
                Thread.Sleep(oneSecond);

                timeLeft -= 1;
            }

            NotifyStopCountdown?.Invoke(this, new TimerEventArgs(message, timeLeft));
        }
    }
}
