using System.Threading;

namespace Timer.Core
{
    /// <summary>
    /// Класс для имитации часов с обратным отсчетом (таймер)
    /// </summary>
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

        public void RunTimer(int timeLeft)
        {
            NotifyStartCountdown?.Invoke(this, new TimerEventArgs(Name, timeLeft));

            CountdownTimer(timeLeft);

            NotifyStopCountdown?.Invoke(this, new TimerEventArgs(Name, timeLeft));
        }

        private void CountdownTimer(int timeLeft)
        {
            while (timeLeft > 0)
            {
                // Передаем подписавшемуся на событие типу, сколько секунд осталось.
                NotifyCountdownLeft?.Invoke(timeLeft);
                // Одна секунда равна 1000 миллисекундам
                const int oneSecond = 1000;
                Thread.Sleep(oneSecond);

                timeLeft -= 1;
            }
        }
    }
}
