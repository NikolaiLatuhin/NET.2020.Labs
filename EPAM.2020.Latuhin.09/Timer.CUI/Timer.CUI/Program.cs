using System;
using Timer.Core;

namespace Timer.CUI
{
    class Program
    {
        static void Main()
        {
            Core.Timer.StartCountdownHandler startCountdown = StartTimeTask;
            Action<string, string> timeComplete = StopTimeTask;

            var timers = new ICutDownNotifier[]
            {
                new HandlesEventsUsingMethods("Чтение задания", startCountdown, timeComplete),
                new HandlesEventsUsingAnonymousDelegates("Выполнение задания", startCountdown, timeComplete),
                new HandlesEventsUsingLambda("Проверка задания перед отправкой", startCountdown, timeComplete),
            };

            Console.WriteLine("Enter the number of seconds for the timer");
            var stringTimeLeft = Console.ReadLine();
            int.TryParse(stringTimeLeft, out var timeLeft);

            foreach (var timer in timers)
            {
                timer.Init();
                timer.Run(timeLeft);
            }
        }

        public static void StartTimeTask(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Start timer. Time for timer {e.TimeSeconds}. Event source {sender}");
        }

        public static void StopTimeTask(string nameTask, string leftTime)
        {
            Console.WriteLine($"Stop timer. Name of task {nameTask}. Time for timer {leftTime}");
        }
        
    }
}
