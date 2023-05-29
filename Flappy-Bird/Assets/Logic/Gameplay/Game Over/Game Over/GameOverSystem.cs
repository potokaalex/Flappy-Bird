using System.Collections.Generic;
using FlappyBird.Infrastructure;
using Entitas;
using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using UnityEngine;

namespace FlappyBird.Ecs.Defeat
{
    public class GameOverSystem : ReactiveSystem<InputEntity>
    {
        private readonly InputContext _inputContext;
        private readonly IStateMachine _stateMachine;
        private readonly IGroup<LevelEntity> _pipes;
        private readonly LevelContext _levelContext;
        private readonly PipesSystems _pipesSystems;
        private readonly BirdSystems _birdSystems;

        public GameOverSystem(LevelContext levelContext, InputContext inputContext, BirdSystems birdSystems,
            PipesSystems pipesSystems, IStateMachine stateMachine) : base(inputContext)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
            _stateMachine = stateMachine;

            _birdSystems = birdSystems;
            _pipesSystems = pipesSystems;

            _pipes = levelContext.GetGroup(LevelMatcher.Pipes);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.Collision.Added());

        protected override bool Filter(InputEntity inputEntity)
            => IsSenderHasBird(inputEntity);

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
                Handle(inputEntity);
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
            {
                RebuildEcs();
                _inputContext.isGameOver = true;
            }
            else if (IsTriggerHasGrass(inputEntity))
            {
                //_inputContext.isGameOver = true;
                _stateMachine.SwitchTo<GameOverState>();
            }
        }

        private void RebuildEcs()
        {
            RebuildBird();

            foreach (var pipes in _levelContext.GetEntities(LevelMatcher.Pipes))
                RebuildPipes(pipes);
        }

        private void RebuildBird()
        {
            //_birdSystems.Cleanup();
            //_levelContext.birdEntity.rotationVelocity.Value = _levelContext.birdData.CounterClockwiseAngularVelocity;
        }

        private void RebuildPipes(LevelEntity pipes)
        {
            foreach (var collider in pipes.linkToGameObject.GameObject.GetComponentsInChildren<Collider2D>())
                collider.enabled = false;

            pipes.velocity.Value = Vector2.zero;
            
            _pipesSystems.Cleanup();
        }
    }
}