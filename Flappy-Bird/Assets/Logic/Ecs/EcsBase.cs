﻿using FlappyBird.Ecs.Gameplay.Pipes;
using FlappyBird.Ecs.Gameplay.Bird;
using FlappyBird.Ecs.Gameplay;
using FlappyBird.Ecs.Defeat;
using FlappyBird.Ecs.Basic;
using Entitas.Unity;

namespace FlappyBird
{
    public class EcsBase
    {
        private readonly DataProvider _data;
        private readonly Contexts _contexts;

        public EcsBase(DataProvider dataProvider, IStateMachine stateMachine, IGameLoop gameLoop)
        {
            _data = dataProvider;
            _contexts = Contexts.sharedInstance = new();

            BasicSystems = new(_contexts, stateMachine, gameLoop);
            GameplaySystems = new(_contexts, gameLoop);
            DefeatSystems = new(_contexts, dataProvider, stateMachine, gameLoop);
        }

        public BasicSystems BasicSystems { get; }

        public GameplaySystems GameplaySystems { get; }

        public DefeatSystems DefeatSystems { get; }

        public Contexts Contexts => _contexts;

        public void CreateEntities()
        {
            CreateBird(_data.BirdConfiguration);
            CreatePipes(_data.PipesConfiguration);
        }

        public void Reset()
        {
            foreach (var entity in _contexts.level.GetEntities())
            {
                if (entity.hasLinkToGameObject)
                    entity.linkToGameObject.GameObject.Unlink();

                entity.Destroy();
            }
        }

        private void CreateBird(BirdConfiguration config)
        {
            _contexts.level.SetBirdData(
                config.FlyUpAction,
                config.FlyUpVelocity,
                config.ClockwiseAngularVelocity,
                config.CounterClockwiseAngularVelocity);

            new BirdFactory(_contexts.level, _contexts.input, config).Create();
        }

        private void CreatePipes(PipesConfiguration config)
        {
            _contexts.level.SetPipesData(new(_contexts.level, config),
                config.SpawnDelay, config.SpawnRate, config.RemoveRate);
        }
    }
}