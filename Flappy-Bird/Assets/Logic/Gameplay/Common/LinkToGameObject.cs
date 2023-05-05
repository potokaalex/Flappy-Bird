using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Common
{
    [Level]
    public class LinkToGameObject : IComponent
    {
        public GameObject GameObject;
    }
}
