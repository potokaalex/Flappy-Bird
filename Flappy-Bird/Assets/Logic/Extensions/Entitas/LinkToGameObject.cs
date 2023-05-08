using UnityEngine;
using Entitas;

namespace FlappyBird.Extensions
{
    [Level]
    public class LinkToGameObject : IComponent
    {
        public GameObject GameObject;
    }
}
