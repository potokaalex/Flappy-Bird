using UnityEngine.EventSystems;
using Entitas;

namespace FlappyBird.Ecs.Gameplay.Bird
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
            if (_levelContext.birdData.FlyUpAction.WasPressedThisFrame() &&
                EventSystem.current.IsPointerOverGameObject() == false)
                _inputContext.isFlyUp = true;
        }
    }
}