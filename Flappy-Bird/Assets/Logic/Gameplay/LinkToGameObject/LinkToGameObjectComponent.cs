using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay
{
    [Level]
    public class LinkToGameObjectComponent : IComponent
    {
        public GameObject GameObject;
    }
}
