using Entitas;

namespace FlappyBird.Gameplay.Input
{
    public class InputSystems : Systems
    {
        public InputSystems(InputContext context)
        {
            context.isInput = true;

            Add(new InputCleanupSystem(context));
        }
    }
}
