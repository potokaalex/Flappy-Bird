using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class DeathSystem : ReactiveSystem<LevelEntity>
    {
        public DeathSystem(LevelContext context) : base(context)
        { }

        protected override ICollector<LevelEntity> GetTrigger(IContext<LevelEntity> context)
            => context.CreateCollector(LevelMatcher.AllOf(LevelMatcher.Collision).Added());

        protected override bool Filter(LevelEntity entity)
            => entity.isBird;

        protected override void Execute(List<LevelEntity> entities)
        {
            foreach (var bird in entities)
            {
                Debug.Log("Game over!");
            }
        }
    }
}
