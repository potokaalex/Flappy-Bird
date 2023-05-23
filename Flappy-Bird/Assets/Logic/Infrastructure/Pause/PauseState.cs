namespace FlappyBird.Infrastructure
{
    public class PauseState : IState
    {
        private readonly DataProvider _data;

        public PauseState(DataProvider data)
            => _data = data;

        public void Enter() 
            => _data.Ecs.BasicSystems.Dispose();

        public void Exit() 
            => _data.Ecs.BasicSystems.Initialize();
    }
}