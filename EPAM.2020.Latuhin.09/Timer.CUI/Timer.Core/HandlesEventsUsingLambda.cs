using System;

namespace Timer.Core
{
    /// <summary>
    /// Класс, обрабатывает события с помощью лямбда выражений
    /// </summary>
    public class HandlesEventsUsingLambda : ICutDownNotifier
    {
        public Timer Timer;
        public Timer.StartCountdownHandler StartTimeTask;
        public Action<string, string> TimeComplete;

        public HandlesEventsUsingLambda(string name, Timer.StartCountdownHandler startTimeTask, Action<string, string> timeComplete)
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
            Timer.NotifyStartCountdown += (object sender, TimerEventArgs e) =>
            {
                Console.WriteLine($"Name of timer {Timer.Name}");
                StartTimeTask(sender, e);
            };

            Timer.NotifyCountdownLeft += (int timeLeft) =>
            {
                Console.WriteLine($"Name of timer {Timer.Name}");
                Console.WriteLine($"Left seconds {timeLeft}");
            };

            Timer.NotifyStopCountdown += (object sender, TimerEventArgs e) =>
            {
                Console.WriteLine($"Name of timer {Timer.Name}");
                TimeComplete(Timer.Name, e.TimeSeconds.ToString());
            };
        }

        /// <summary>
        /// Запускает «таймер»
        /// </summary>
        /// <param name="timeSecondsLeft">Количество секунд для запуска таймера</param>
        public void Run(int timeSecondsLeft)
        {
            Timer.RunTimer(timeSecondsLeft);
        }
    }
}
