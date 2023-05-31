using UnityEngine.EventSystems;
using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class InputSystem : IExecuteSystem
    {
        private readonly LevelContext _levelContext;
        private readonly InputContext _inputContext;

        public InputSystem(LevelContext levelContext, InputContext inputContext)
        {
            _levelContext = levelContext;
            _inputContext = inputContext;
        }

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