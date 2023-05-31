namespace FlappyBird.Infrastructure
{
    public class PauseState : IState
    {
        private readonly GameplayEcs _ecs;

        public PauseState(GameplayEcs ecs)
            => _ecs = ecs;

        public void Enter()
        {
            _ecs.StopSystems();
        }

        public void Exit()
        {
        }
    }
}