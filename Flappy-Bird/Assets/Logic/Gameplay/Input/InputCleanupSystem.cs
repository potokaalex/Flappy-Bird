using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Gameplay.Input
{
    public class InputCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private IGroup<InputEntity> _inputEntities;

        public InputCleanupSystem(InputContext context) 
            => _inputEntities = context.GetGroup(InputMatcher.Input);

        public void Execute()
            => Cleanup();

        public void Cleanup()
        {
            foreach (var entity in _inputEntities)
                entity.RemoveAllComponentsExcept(InputComponentsLookup.Input);
        }
    }
}
