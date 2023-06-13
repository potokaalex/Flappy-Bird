using UnityEngine;

namespace FlappyBird.Gameplay.Core.Grass
{
    [CreateAssetMenu(fileName = "New Grass Configuration", menuName = "Configurations/Grass")]
    public class GrassStaticData : ScriptableObject
    {
        [SerializeField] private float _scrollVelocityY;

        public float ScrollVelocity => _scrollVelocityY;
    }
}