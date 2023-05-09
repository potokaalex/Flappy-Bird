using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class BirdEntityFactory : Systems
    {
        private LevelContext _context;

        public BirdEntityFactory(LevelContext context)
            => _context = context;

        public LevelEntity Create()
        {
            var entity = _context.CreateEntity();

            entity.isBird = true;

            return entity;
        }
    }
}
