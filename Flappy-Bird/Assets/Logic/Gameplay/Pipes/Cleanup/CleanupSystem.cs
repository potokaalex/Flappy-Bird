using Entitas.Unity;
using UnityEngine;
using Entitas;

namespace FlappyBird.Gameplay.Pipes
{
    public class CleanupSystem : ICleanupSystem
    {
        private readonly LevelContext _context;
        private readonly IGroup<LevelEntity> _pipes;

        public CleanupSystem(LevelContext context)
        {
            _context = context;
            _pipes = context.GetGroup(LevelMatcher.Pipes);
        }

        public void Cleanup()
        {
            foreach (var entity in _pipes.GetEntities())
                DestroyPipes(entity);

            _context.RemovePipesData();
        }

        private void DestroyPipes(LevelEntity pipes)
        {
            var gameObject = pipes.linkToGameObject.GameObject;

            gameObject.Unlink();
            Object.Destroy(gameObject);
            pipes.Destroy();
        }
    }
}