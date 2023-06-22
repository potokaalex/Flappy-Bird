using UnityEngine;
using System;

namespace FlappyBird.Gameplay.Core.Bird
{
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