using Entitas.CodeGeneration.Attributes;
using Entitas;
using System;

namespace FlappyBird.Ecs.Gameplay.Bird
{
    [Serializable, Input, Unique]
    public class FlyUpComponent : IComponent
    {
    }
}