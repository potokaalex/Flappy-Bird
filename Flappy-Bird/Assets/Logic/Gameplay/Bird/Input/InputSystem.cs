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
            if (_levelContext.flyUpData.Action.WasPressedThisFrame())
                _inputContext.isFlyUp = true;
        }
    }
}