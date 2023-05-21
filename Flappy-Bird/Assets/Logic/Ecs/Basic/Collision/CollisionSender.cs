using UnityEngine;

namespace FlappyBird.Ecs.Basic.Collision
{
    public class CollisionSender : MonoBehaviour
    {
        private InputContext _context;

        public void Initialize(InputContext context)
            => _context = context;

        private void OnCollisionEnter2D(Collision2D collision)
            => _context.SetCollision(collision);
    }
}