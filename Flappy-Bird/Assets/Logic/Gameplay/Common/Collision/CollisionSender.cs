using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Gameplay.Common.Collision
{
    public class CollisionSender : MonoBehaviour
    {
        [SerializeField] private EntityLink _link;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var index = LevelComponentsLookup.Collision;

            _link.entity.AddComponent(index, _link.entity.CreateComponent<CollisionComponent>(index));
        }
    }
}
