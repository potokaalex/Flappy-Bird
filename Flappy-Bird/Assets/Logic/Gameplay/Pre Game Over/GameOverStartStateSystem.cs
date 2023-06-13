using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Infrastructure;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverStartStateSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<InputEntity> _collisions;
        private readonly IStateMachine _stateMachine;

        public GameOverStartStateSystem(IStateMachine stateMachine, InputContext inputContext)
        {
            _collisions = inputContext.GetGroup(InputMatcher.Collision);
            _stateMachine = stateMachine;
        }

        public void Initialize() 
            => Execute();

        public void Execute()
        {
            foreach (var collision in _collisions)
                if (IsSenderHasBird(collision) && IsTriggerHasGrass(collision))
                    StartState();
        }

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private void StartState()
            => _stateMachine.SwitchTo<GameOverState>();
    }
}