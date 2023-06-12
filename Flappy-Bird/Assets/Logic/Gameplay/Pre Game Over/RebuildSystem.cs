using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.GameOver
{
    public class RebuildSystem : IInitializeSystem
    {
        private readonly IGroup<LevelEntity> _pipes;

        public RebuildSystem(LevelContext levelContext) 
            => _pipes = levelContext.GetGroup(LevelMatcher.Pipes);

        public void Initialize()
        {
            foreach (var pipes in _pipes.GetEntities())
                RebuildPipes(pipes);
        }
        
        private void RebuildPipes(LevelEntity pipes)
        {
            foreach (var collider in pipes.linkToGameObject.GameObject.GetComponentsInChildren<Collider2D>())
                collider.enabled = false;

            pipes.velocity.Value = Vector2.zero;
        }
    }
}