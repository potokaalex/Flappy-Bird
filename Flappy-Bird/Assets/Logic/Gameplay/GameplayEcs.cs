using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using FlappyBird.Gameplay.Basic;
using FlappyBird.Ecs.Defeat;
using Entitas.Unity;
using Entitas;

namespace FlappyBird
{
    public class GameplayEcs //start stop systems!
    {
        private readonly Systems _systems;
        private readonly Contexts _contexts;
        private readonly IGameLoop _gameLoop;
        private readonly DataProvider _data;

        public GameplayEcs(DataProvider data, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _contexts = Contexts.sharedInstance;
            _systems = CreateSystems(data, stateMachine, gameLoop);
            _gameLoop = gameLoop;
            _data = data;
        }

        public void InitializeSystems()
        {
            _systems.Initialize();
            //_gameLoop.OnFixedUpdate += _devSystems.Execute;
        }

        public void DisposeSystems()
        {
            _systems.Cleanup();
            //_gameLoop.OnFixedUpdate -= _devSystems.Execute;
        }

        public void CreateEntities()
        {
            CreateBird(_data.BirdConfig);
            CreatePipes(_data.PipesConfig);
            CreateTime();
        }

        public void DestroyAllEntities()
        {
            foreach (var entity in _contexts.level.GetEntities())
            {
                if (entity.hasLinkToGameObject)
                    if (entity.linkToGameObject.GameObject != null)
                        entity.linkToGameObject.GameObject.Unlink();
            }
            
            _contexts.Reset();
        }

        private void CreateBird(BirdConfiguration config)
        {
            _contexts.level.SetBirdData(
                config.FlyUpAction,
                config.FlyUpVelocity,
                config.ClockwiseAngularVelocity,
                config.CounterClockwiseAngularVelocity,
                config.VelocityToFlyRotation,
                config.VelocityToFallRotation);

            new BirdFactory(_contexts.level, _contexts.input, _data.BirdConfig,
                _data.PlayerProgress.BirdSpawnPoint).Create();
        }

        private void CreatePipes(PipesConfiguration config)
        {
            _contexts.level.SetPipesData(new(_contexts.level, config),
                config.SpawnDelay, config.SpawnRate, config.RemoveRate);
        }

        private void CreateTime()
            => _contexts.input.SetTime(0);

        private Systems CreateSystems(DataProvider data, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            var birdSystems = new BirdSystems(_contexts, data, gameLoop);
            var pipesSystems = new PipesSystems(_contexts, data, gameLoop);

            return new Systems()
                .Add(birdSystems)
                .Add(pipesSystems)
                .Add(new DevSystems(_contexts, data, stateMachine, gameLoop))
                .Add(new GameOverSystems(_contexts, birdSystems, pipesSystems, stateMachine, gameLoop))
                .Add(new BasicSystems(_contexts, gameLoop));
        }
    }
}