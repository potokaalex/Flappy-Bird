using Entitas.CodeGeneration.Attributes;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Core.Bird
{
    [Serializable, Input, Unique]
    public class FlyUpComponent : IComponent
    {
    }
}