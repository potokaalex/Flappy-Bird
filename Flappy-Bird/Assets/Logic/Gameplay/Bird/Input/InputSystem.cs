using UnityEngine.InputSystem;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class InputSystem : IExecuteSystem
    {
        private InputEntity _inputEntity;
        private InputAction _flyUpAction;

        public InputSystem(InputEntity inputEntity, InputAction flyUpAction)
        {
            _inputEntity = inputEntity;
            _flyUpAction = flyUpAction;
        }

        public void Execute()
        {
            if (_flyUpAction.WasPressedThisFrame())
                _inputEntity.isFlyUp = true;
        }
    }
}
