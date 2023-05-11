using Entitas;

namespace FlappyBird.Gameplay.Bird
{
    public class InputSystem : IExecuteSystem
    {
        private IGroup<InputEntity> _inputEntities;
        private BirdConfiguration _config;

        public InputSystem(InputContext context, BirdConfiguration config)
        {
            _inputEntities = context.GetGroup(InputMatcher.Input);
            _config = config;
        }

        public void Execute()
        {
            foreach (var entity in _inputEntities)
                if (_config.FlyUpAction.WasPressedThisFrame())
                    entity.AddFlyUp(_config.FlyUpVelocity);
        }
    }
}
