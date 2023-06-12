using System.Collections.Generic;
using FlappyBird.Infrastructure;
using Entitas;
using FlappyBird.Gameplay.Core.Bird;

namespace FlappyBird.Gameplay.GameOver
{
    public class GameOverStartStateSystem : ReactiveSystem<InputEntity>, IInitializeSystem
    {
        private readonly IStateMachine _stateMachine;
        private readonly InputContext _inputContext;

        public GameOverStartStateSystem(IStateMachine stateMachine, InputContext inputContext) : base(inputContext)
        {
            _inputContext = inputContext;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            foreach (var collision in _inputContext.GetEntities(InputMatcher.Collision))
                if (Filter(collision))
                    StartState();
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision);

        protected override bool Filter(InputEntity entity)
            => IsSenderHasBird(entity) && IsTriggerHasGrass(entity);

        protected override void Execute(List<InputEntity> entities)
            => StartState();

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private void StartState()
            => _stateMachine.SwitchTo<GameOverState>();
    }
}