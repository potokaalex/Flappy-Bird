using System.Collections.Generic;
using FlappyBird.Gameplay.Pipes;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class DeathSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;

        public DeathSystem(InputContext inputContext) : base(inputContext) 
            => _inputContext = inputContext;

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity);

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
                Handle(entity);
        }

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasPipes(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<PipesCollider>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);

        private void Handle(InputEntity inputEntity)
        {
            if (IsTriggerHasPipes(inputEntity))
                GameOver();

            else if (IsTriggerHasGrass(inputEntity))
            {
                _inputContext.isGameOverState = true;
                GameOver();
            }
        }

        private void GameOver()
        {
            _inputContext.birdData.FlyUpAction.Disable();
            _inputContext.isGameOver = true;
        }
    }
}