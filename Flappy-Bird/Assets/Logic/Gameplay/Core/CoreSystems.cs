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

        public CoreSystems(Contexts contexts, IDataProvider dataProvider,
            IStateMachine stateMachine, IGameLoop gameLoop) : base(gameLoop)
        {
            _contexts = contexts;

            base.Add(CreateSystems(contexts, dataProvider, stateMachine, gameLoop));
        }

        public override void Start()
        {
            base.Start();
            _contexts.level.birdEntity.birdAnimations.BirdAnimator.SetActive(true);
            _contexts.input.birdData.FlyUpAction.Enable();
        }

        public override void Stop()
        {
            base.Stop();
            _contexts.level.birdEntity.birdAnimations.BirdAnimator.SetActive(false);
            _contexts.input.birdData.FlyUpAction.Disable();
        }

        private Systems CreateSystems(Contexts contexts, IDataProvider dataProvider,
            IStateMachine stateMachine, IGameLoop gameLoop)
        {
            var systems = new Systems();

            base.Add(new BirdSystems(contexts, dataProvider));
            base.Add(new PipesSystems(contexts, dataProvider));
            base.Add(new GrassSystems(contexts, dataProvider));
            base.Add(new ScoreSystems(contexts));
            base.Add(new PreGameOverStartStateSystem(stateMachine, contexts.input));
            base.Add(new GameOverStartStateSystem(stateMachine, contexts.input));
            base.Add(new CommonSystems(contexts, gameLoop));

            return systems;
        }
    }
}