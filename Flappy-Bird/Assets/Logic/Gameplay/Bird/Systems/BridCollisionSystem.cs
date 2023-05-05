using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BridCollisionSystem : ReactiveSystem<LevelEntity>
    {
        public BridCollisionSystem(LevelContext context) : base(context)
        { }

        protected override ICollector<LevelEntity> GetTrigger(IContext<LevelEntity> context)
            => context.CreateCollector(LevelMatcher.AllOf(LevelMatcher.Collision).Added());

        protected override bool Filter(LevelEntity entity)
            => entity.isBird;

        protected override void Execute(List<LevelEntity> entities)
        {
            Debug.Log("Game over!");
        }
    }
}
