namespace FlappyBird
{
    public interface ISwitchableSystem
    {
        public void Start(IGameLoop gameLoop);

        public void Stop(IGameLoop gameLoop);
    }
}