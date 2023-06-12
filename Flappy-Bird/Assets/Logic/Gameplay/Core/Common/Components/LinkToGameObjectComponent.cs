using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Core
{
    [Level]
    public class LinkToGameObjectComponent : IComponent
    {
        public GameObject GameObject;
    }
}