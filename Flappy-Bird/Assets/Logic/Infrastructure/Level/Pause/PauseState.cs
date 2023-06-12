using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class PauseState : IState
    {
        private readonly GameplayEcs _ecs;

        public PauseState(GameplayEcs ecs)
            => _ecs = ecs;

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}