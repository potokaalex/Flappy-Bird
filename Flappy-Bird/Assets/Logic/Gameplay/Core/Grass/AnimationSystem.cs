using Entitas;
using UnityEngine;

namespace FlappyBird.Gameplay.Core.Grass
{
    public class AnimationSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;

        public AnimationSystem(InputContext inputContext)
            => _inputContext = inputContext;

        public void Execute()
        {
            _inputContext.grassData.Material.mainTextureOffset +=
                Vector2.left * _inputContext.grassData.ScrollVelocityY * _inputContext.time.DeltaTime;
        }
    }
}