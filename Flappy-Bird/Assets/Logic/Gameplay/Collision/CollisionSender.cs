using Entitas.Unity;
using UnityEngine;

namespace FlappyBird.Gameplay.Collision
{
    public class CollisionSender : MonoBehaviour
    {
        [SerializeField] private EntityLink _link;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var index = LevelComponentsLookup.Collision;
            var entity = _link.entity;

            entity.AddComponent(index, entity.CreateComponent<CollisionComponent>(index));
        }
    }
}