using UnityEngine.UI;
using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class SkinCellUI : ButtonBase
    {
        [SerializeField] private Image _skinImage;
        [SerializeField] private Image _selectStatusImage;
        [SerializeField] private Color _selectColor;

        private ISkinApplier _skinApplier;
        private int _skinIndex;

        public void Initialize(ISkinApplier skinApplier, int skinIndex)
        {
            _skinApplier = skinApplier;
            _skinIndex = skinIndex;
            
            _skinImage.gameObject.SetActive(false);
        }

        public void SetSkin(Sprite skinSprite)
        {
            _skinImage.gameObject.SetActive(true);
            _skinImage.sprite = skinSprite;
        }

        public void SetSelect(bool isSelected)
            => _selectStatusImage.color = isSelected ? _selectColor : Color.clear;

        private protected override void OnClick() 
            => _skinApplier.ApplySkin(_skinIndex);
    }
}