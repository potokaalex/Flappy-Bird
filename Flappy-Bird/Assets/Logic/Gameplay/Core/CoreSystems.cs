using FlappyBird.Gameplay.PreGameOver;
using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Score;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.GameOver;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    public class CoreSystems : GameplaySystems
    {
        private readonly Contexts _contexts;

        public CoreSystems(Contexts contexts, IDataProvider dataProvider, IStateMachine stateMachine,
            IGameLoop gameLoop, IPlayerProgress playerProgress)
        {
            _contexts = contexts;

            base.Add(CreateSystems(contexts, dataProvider, stateMachine, gameLoop, playerProgress));
        }

        public override void Start(IGameLoop gameLoop)
        {
            _contexts.level.birdEntity.birdAnimations.BirdAnimator.SetActive(true);
            _contexts.input.birdData.FlyUpAction.Enable();

            ActivateReactiveSystems();
            Initialize();
            gameLoop.OnFixedUpdate += Execute;
            base.Start(gameLoop);
        }

        public override void Stop(IGameLoop gameLoop)
        {
            _contexts.level.birdEntity.birdAnimations.BirdAnimator.SetActive(false);
            _contexts.input.birdData.FlyUpAction.Disable();

            DeactivateReactiveSystems();
            gameLoop.OnFixedUpdate -= Execute;
            base.Stop(gameLoop);
        }

        private Systems CreateSystems(Contexts contexts, IDataProvider dataProvider,
            IStateMachine stateMachine, IGameLoop gameLoop, IPlayerProgress playerProgress)
        {
            var systems = new Systems();

            base.Add(new BirdSystems(contexts, dataProvider));
            base.Add(new PipesSystems(contexts, dataProvider));
            base.Add(new GrassSystems(contexts, dataProvider));
            base.Add(new ScoreSystems(contexts, dataProvider, playerProgress));
            base.Add(new PreGameOverStartStateSystem(stateMachine, contexts.input));
            base.Add(new GameOverStartStateSystem(stateMachine, contexts.input));
            base.Add(new CommonSystems(contexts, gameLoop));

            return systems;
        }
    }
}