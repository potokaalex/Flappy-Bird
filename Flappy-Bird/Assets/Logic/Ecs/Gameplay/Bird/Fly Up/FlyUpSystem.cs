using System.Collections.Generic;
using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    public class FlyUpSystem : ReactiveSystem<InputEntity>
    {
        private readonly LevelContext _levelContext;
        private readonly IGroup<LevelEntity> _birdEntities;

        public FlyUpSystem(LevelContext levelContext, InputContext inputContext)
            : base(inputContext)
        {
            _levelContext = levelContext;
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
            => entity.verticalVelocity.Value = _levelContext.birdData.FlyUpVelocity;
    }
}