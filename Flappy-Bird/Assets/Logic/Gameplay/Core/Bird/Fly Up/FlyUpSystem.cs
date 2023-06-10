using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class FlyUpSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;
        private readonly IGroup<LevelEntity> _birdEntities;

        public FlyUpSystem(LevelContext levelContext, InputContext inputContext)
            : base(inputContext)
        {
            _inputContext = inputContext;
            _birdEntities = levelContext.GetGroup(LevelMatcher.Bird);
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
            => entity.velocity.Value = new(0, _inputContext.birdData.FlyUpVelocity);
    }
}