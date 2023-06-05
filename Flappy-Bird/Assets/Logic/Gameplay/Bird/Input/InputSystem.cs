using UnityEngine.EventSystems;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class InputSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;

        public InputSystem(InputContext inputContext) 
            => _inputContext = inputContext;

        public void Execute()
        {
            if (_inputContext.birdData.FlyUpAction.WasPressedThisFrame() &&
                EventSystem.current.IsPointerOverGameObject() == false)
                SendFlyUpEvent();
        }

        private void SendFlyUpEvent()
        {
            var entity = _inputContext.CreateEntity();

            entity.isFlyUp = true;
            entity.isEvent = true;
        }
    }
}