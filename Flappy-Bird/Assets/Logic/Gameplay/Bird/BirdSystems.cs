using UnityEngine.InputSystem;
using FlappyBird.Extensions;
using Entitas;
using UnityEngine;
using Entitas.Unity;


namespace FlappyBird.Gameplay.Bird
{
    public class BirdSystems : Feature
    {
        public BirdSystems(Contexts contexts, BirdConfiguration birdConfig, DeltaTime deltaTime)
        {
            Add(new BirdInitializationSystem(contexts.level.birdEntity, birdConfig));
            Add(new InputSystem(contexts.input.inputEntity, birdConfig.FlyUpAction));
            Add(new DeathSystem(contexts.level));
            Add(new GravitySystem(contexts.level, deltaTime));
            Add(new BirdCleanupSystem(contexts.level.birdEntity));
            //move
        }
    }
}
