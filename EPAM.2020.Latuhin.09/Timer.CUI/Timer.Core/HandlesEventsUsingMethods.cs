using System;

namespace Timer.Core
{
    /// <summary>
    /// Класс, обрабатывает события с помощью методов
    /// </summary>
    public class HandlesEventsUsingMethods : ICutDownNotifier
    {
        public Timer Timer;
        public Timer.StartCountdownHandler StartTimeTask;
        public Action<string, string> TimeComplete;

        public HandlesEventsUsingMethods(string name, Timer.StartCountdownHandler startTimeTask, Action<string,string> timeComplete)
        {
            Timer = new Timer(name);
            StartTimeTask = startTimeTask;
            TimeComplete = timeComplete;
        }

        /// <summary>
        /// Подписывается на событие «таймера»
        /// </summary>
        public void Init()
        {
            Timer.NotifyStartCountdown += StartCountdown;
            Timer.NotifyCountdownLeft += CountdownLeft;
            Timer.NotifyStopCountdown += StopCountdown;
        }

        /// <summary>
        /// Запускает «таймер»
        /// </summary>
        /// <param name="timeSecondsLeft">Количество секунд для запуска таймера</param>
        public void Run(int timeSecondsLeft)
        {
            Timer.RunTimer(timeSecondsLeft);
        }

        public void StartCountdown(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Name of timer {Timer.Name}");
            StartTimeTask(sender, e);
        }

        public void CountdownLeft(int timeLeft)
        {
            Console.WriteLine($"Name of timer {Timer.Name}");
            Console.WriteLine($"Left seconds {timeLeft}");
        }

        public void StopCountdown(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Name of timer {Timer.Name}");
            TimeComplete(Timer.Name, e.TimeSeconds.ToString());
        }
    }
}
