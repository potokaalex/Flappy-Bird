using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    [Level]
    public class LinkToGameObjectComponent : IComponent
    {
        public GameObject GameObject;
    }
}