using Entitas.Unity;
using Entitas;

namespace FlappyBird.Ecs.Gameplay.Pipes
{
    public class CleanupSystem : ICleanupSystem
    {
        private readonly IGroup<LevelEntity> _pipes;

        public CleanupSystem(LevelContext context) 
            => _pipes = context.GetGroup(LevelMatcher.Pipes);

        public void Cleanup()
        {
            foreach (var entity in _pipes.GetEntities())
                DestroyPipes(entity);
        }

        private void DestroyPipes(LevelEntity pipes)
        {
            pipes.linkToGameObject.GameObject.Unlink();
            pipes.Destroy();
        }
    }
}