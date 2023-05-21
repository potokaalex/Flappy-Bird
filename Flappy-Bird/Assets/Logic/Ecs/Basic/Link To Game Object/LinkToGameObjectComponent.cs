using UnityEngine;
using Entitas;

namespace FlappyBird.Ecs.Basic
{
    [Level]
    public class LinkToGameObjectComponent : IComponent
    {
        public GameObject GameObject;
    }
}