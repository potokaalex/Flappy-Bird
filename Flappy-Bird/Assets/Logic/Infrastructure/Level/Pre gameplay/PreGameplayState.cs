using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class PreGameplayState : IState
    {
        private readonly GameplayEcs _ecs;

        public PreGameplayState(GameplayEcs ecs) 
            => _ecs = ecs;

        public void Enter()
        {
            _ecs.Initialize();
            
            _ecs.PreGameplaySystems.Start();
        }

        public void Exit() 
            => _ecs.PreGameplaySystems.Stop();
    }
}