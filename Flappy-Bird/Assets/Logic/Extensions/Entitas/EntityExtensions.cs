using Entitas;

namespace FlappyBird.Extensions
{
    public static class EntityExtensions
    {
        public static void RemoveAllComponentsExcept(this IEntity entity, params int[] indexes)
        {
            for (var i = 0; i < entity.totalComponents; i++)
                if (!indexes.Contains(i))
                    entity.ReplaceComponent(i, null);
        }
    }
}
