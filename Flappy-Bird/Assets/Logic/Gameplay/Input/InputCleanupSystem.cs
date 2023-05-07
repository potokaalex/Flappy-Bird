using Entitas;

namespace FlappyBird.Gameplay.Input
{
    public class InputCleanupSystem : IExecuteSystem
    {
        private InputEntity _inputEntity;

        public InputCleanupSystem(InputEntity inputEntity)
            => _inputEntity = inputEntity;

        public void Execute()
        {
            for (int i = 0; i < _inputEntity.totalComponents; i++)
            {
                if (i == InputComponentsLookup.Input)
                    continue;

                _inputEntity.ReplaceComponent(i, null);
            }
        }
    }
}
