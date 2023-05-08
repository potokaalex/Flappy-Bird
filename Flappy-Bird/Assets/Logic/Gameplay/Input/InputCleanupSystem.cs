using FlappyBird.Extensions;
using Entitas;

namespace FlappyBird.Gameplay.Input
{
    public class InputCleanupSystem : IExecuteSystem, ICleanupSystem
    {
        private InputEntity _inputEntity;

        public InputCleanupSystem(InputEntity inputEntity)
            => _inputEntity = inputEntity;

        public void Execute()
            => Cleanup();
        
        public void Cleanup()
            => _inputEntity.RemoveAllComponentsExcept(InputComponentsLookup.Input);
    }
}
