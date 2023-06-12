using FlappyBird.Gameplay;

namespace FlappyBird
{
    public class PreGameOverState : IState
    {
        private readonly GameplayEcs _ecs;

        public PreGameOverState(GameplayEcs ecs) 
            => _ecs = ecs;

        public void Enter()
        {
            _ecs.PreGameOverSystems.Initialize();
            _ecs.PreGameOverSystems.Start();
        }

        public void Exit() 
            => _ecs.PreGameOverSystems.Stop();
    }
}