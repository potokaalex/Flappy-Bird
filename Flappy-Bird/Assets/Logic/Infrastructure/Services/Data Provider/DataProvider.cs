namespace FlappyBird
{
    public class DataProvider
    {
        public PlayerProgress PlayerProgress { get; private set; }

        public void Initialize(DataProviderConfiguration config)
        {
            PlayerProgress = new();
        }
    }
}