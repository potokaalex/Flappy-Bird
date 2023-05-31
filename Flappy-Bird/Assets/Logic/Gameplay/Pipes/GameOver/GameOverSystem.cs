using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class GameOverSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<LevelEntity> _pipes;

        public GameOverSystem(LevelContext levelContext, InputContext inputContext) : base(inputContext)
            => _pipes = levelContext.GetGroup(LevelMatcher.Pipes);

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.GameOver.Added());

        protected override bool Filter(InputEntity inputEntity)
            => true;

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var pipes in _pipes.GetEntities())
                RebuildPipes(pipes);
        }

        private void RebuildPipes(LevelEntity pipes)
        {
            foreach (var collider in pipes.linkToGameObject.GameObject.GetComponentsInChildren<Collider2D>())
                collider.enabled = false;

            pipes.velocity.Value = Vector2.zero;
        }
    }
}