using Entitas;
using UnityEngine;

namespace FlappyBird.Gameplay.Core
{
    public class CollisionSender : MonoBehaviour
    {
        private InputContext _context;

        public void Initialize(InputContext context)
            => _context = context;

        private void OnCollisionEnter2D(Collision2D collision)
            => SendCollisionEvent(collision);

        private void SendCollisionEvent(Collision2D collision)
        {
            var entity = _context.CreateEntity();

            entity.AddCollision(new()
            {
                Collider =  collision.collider,
                OtherCollider = collision.otherCollider
            });
            
            entity.isEvent = true;
        }
    }
}