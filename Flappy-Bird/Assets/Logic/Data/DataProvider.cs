namespace FlappyBird
{
    public class DataProvider
    {
        public SceneLoadingConfiguration LevelLoadingConfig { get; private set; }
        public PlayerProgress PlayerProgress { get; private set; }

        public void Initialize(DataProviderConfiguration config)
        {
            LevelLoadingConfig = config.LevelLoadingConfig;
            PlayerProgress = new();
        }
    }
}