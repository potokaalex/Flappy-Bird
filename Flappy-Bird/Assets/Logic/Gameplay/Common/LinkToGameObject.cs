using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Common
{

    [Game]
    public class LinkToGameObject : IComponent
    {
        public GameObject GameObject;
    }
}
