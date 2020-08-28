namespace Timer.Core
{
    public interface ICutDownNotifier
    {
        void Init();
        void Run(int timeSecondsLeft);
    }
}
