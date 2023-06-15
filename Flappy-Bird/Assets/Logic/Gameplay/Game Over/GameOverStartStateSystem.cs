using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Infrastructure;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverStartStateSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _collisions;
        private readonly IStateMachine _stateMachine;

        public GameOverStartStateSystem(IStateMachine stateMachine, InputContext inputContext)
        {
            _stateMachine = stateMachine;
            _collisions = inputContext.GetGroup(InputMatcher.Collision);
        }

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.OtherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.Collider.TryGetComponent<GrassCollider>(out _);

        public void Execute()
        {
            foreach (var entity in _collisions)
            {
                if (IsSenderHasBird(entity) && IsTriggerHasGrass(entity))
                {
                    _stateMachine.SwitchTo<GameOverState>();
                }
            }
        }
    }
}