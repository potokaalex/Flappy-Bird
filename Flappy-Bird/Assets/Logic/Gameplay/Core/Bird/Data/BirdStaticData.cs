using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace FlappyBird.Gameplay.Core.Bird
{
    [CreateAssetMenu(fileName = "New Bird Configuration", menuName = "Configurations/Bird")]
    public class BirdStaticData : ScriptableObject, IData
    {
        [SerializeField] private InputAction _flyUpAction;
        [SerializeField] private BirdAppearance _appearance;

        [SerializeField] private float _gravityAcceleration;
        [SerializeField] private float _flyUpVelocity;
        [SerializeField] private float _velocityToFallAnimation;

        [SerializeField] private float _minVelocityY;
        [SerializeField] private float _maxVelocityY;
        [SerializeField] private float _minPositionY;
        [SerializeField] private float _maxPositionY;

        public InputAction FlyUpAction => _flyUpAction;

        public BirdAppearance Appearance => _appearance;

        public float GravityAcceleration => _gravityAcceleration;

        public float FlyUpVelocity => _flyUpVelocity;

        public float VelocityToFallAnimation => _velocityToFallAnimation;

        public float MinVelocityY => _minVelocityY;

        public float MaxVelocityY => _maxVelocityY;

        public float MinPositionY => _minPositionY;

        public float MaxPositionY => _maxPositionY;
    }

    [Serializable]
    public struct BirdAppearance 
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Sprite[] _skins;

        public GameObject Prefab
            => _prefab;
        
        public Sprite GetSkin(int index)
            => _skins[index];
    }
}