using System.Collections.Generic;
using FlappyBird.Gameplay.Pipes;
using FlappyBird.Gameplay.Bird;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class RebuildSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<LevelEntity> _pipes;
        private readonly PipesSystems _pipesSystems;
        private readonly BirdSystems _birdSystems;

        public RebuildSystem(LevelContext levelContext,BirdSystems birdSystems, PipesSystems pipesSystems,
            InputContext inputContext) : base(inputContext)
        {
            _birdSystems = birdSystems;
            _pipesSystems = pipesSystems;
            _pipes = levelContext.GetGroup(LevelMatcher.Pipes);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision);

        protected override bool Filter(InputEntity entity)
            => IsSenderHasBird(entity) && (IsTriggerHasPipes(entity) || IsTriggerHasGrass(entity));

        protected override void Execute(List<InputEntity> entities)
        {
            _birdSystems.Stop();
            _pipesSystems.Stop();

            foreach (var pipes in _pipes.GetEntities())
                RebuildPipes(pipes);
        }

        private bool IsSenderHasBird(InputEntity inputEntity)
            => inputEntity.collision.Info.otherCollider.TryGetComponent<BirdCollider>(out _);

        private bool IsTriggerHasPipes(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<PipesCollider>(out _);

        private bool IsTriggerHasGrass(InputEntity inputEntity)
            => inputEntity.collision.Info.collider.TryGetComponent<GrassCollider>(out _);

        private void RebuildPipes(LevelEntity pipes)
        {
            foreach (var collider in pipes.linkToGameObject.GameObject.GetComponentsInChildren<Collider2D>())
                collider.enabled = false;

            pipes.velocity.Value = Vector2.zero;
        }
    }
}