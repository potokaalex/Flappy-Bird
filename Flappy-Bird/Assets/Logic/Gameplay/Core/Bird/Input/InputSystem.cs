using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Entitas;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class InputSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;

        public InputSystem(InputContext inputContext)
            => _inputContext = inputContext;

        public void Execute()
        {
            if (_inputContext.birdData.FlyUpAction.WasPressedThisFrame() && !IsPointerOverUIObject())
                SendFlyUpEvent();
        }

        private void SendFlyUpEvent()
        {
            var entity = _inputContext.CreateEntity();

            entity.isFlyUp = true;
            entity.isEvent = true;
        }

        private bool IsPointerOverUIObject()
        {
            var touchPosition = Touchscreen.current.position.ReadValue();
            var eventData = new PointerEventData(EventSystem.current);
            var results = new List<RaycastResult>();

            eventData.position = touchPosition;
            EventSystem.current.RaycastAll(eventData, results);

            return results.Count > 0;
        }
    }
}