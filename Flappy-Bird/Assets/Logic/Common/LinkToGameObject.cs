using UnityEngine;
using Entitas;

namespace FlappyBird.Common//gamePlay ?
{
    [Game]
    public class LinkToGameObject : IComponent
    {
        public GameObject GameObject;
    }
}
