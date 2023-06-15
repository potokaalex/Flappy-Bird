namespace FlappyBird.Gameplay
{
    public abstract class GameplaySystems : Feature
    {
        private readonly IGameLoop _gameLoop;

        protected GameplaySystems(IGameLoop gameLoop)
        {
            DeactivateReactiveSystems();
            _gameLoop = gameLoop;
        }

        public virtual void Start()
        {
            ActivateReactiveSystems();
            _gameLoop.OnFixedUpdate += Execute;
        }

        public virtual void Stop()
        {
            DeactivateReactiveSystems();
            _gameLoop.OnFixedUpdate -= Execute;
        }
    }
}