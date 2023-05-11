using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class FlyUpSystem : ReactiveSystem<InputEntity>
    {
        private IGroup<LevelEntity> _birdEntities;
        private InputContext _inputContext;

        public FlyUpSystem(LevelContext levelContext, InputContext inputContext)
            : base(inputContext)
        {
            _birdEntities = levelContext.GetGroup(LevelMatcher.Bird);
            _inputContext = inputContext;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.FlyUp.Added());

        protected override bool Filter(InputEntity entity)
            => true;

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var bird in _birdEntities)
                SetVelocity(bird);
        }

        private void SetVelocity(LevelEntity entity)
            => entity.verticalVelocity.Value = _inputContext.flyUp.Velocity;
    }
}
