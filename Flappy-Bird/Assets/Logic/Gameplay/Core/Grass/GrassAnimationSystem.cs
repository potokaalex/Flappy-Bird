using Entitas;
using UnityEngine;

namespace FlappyBird.Gameplay.Core.Grass
{
    public class GrassAnimationSystem : IExecuteSystem
    {
        private readonly InputContext _inputContext;

        public GrassAnimationSystem(InputContext inputContext)
            => _inputContext = inputContext;

        public void Execute()
        {
            _inputContext.grassData.Material.mainTextureOffset +=
                Vector2.left * _inputContext.grassData.ScrollVelocityY * _inputContext.time.DeltaTime;
        }
    }
}