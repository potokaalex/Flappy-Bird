using FlappyBird.Gameplay.Core.Bird;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class BirdSkinsBoardUI : MonoBehaviour, ISkinApplier
    {
        [SerializeField] private SkinsBoardUIAnimator _animator;
        [SerializeField] private SkinCellUI[] _skinCells;

        private IDataProvider _dataProvider;
        private ProgressData _progressData;

        [Inject]
        private void Constructor(IDataProvider dataProvider)
            => _dataProvider = dataProvider;

        public SkinsBoardUIAnimator Animator
            => _animator;

        private void Start()
        {
            var birdStaticData = _dataProvider.Get<BirdStaticData>();

            _progressData = _dataProvider.Get<ProgressData>();

            for (var i = 0; i < _skinCells.Length; i++)
            {
                _skinCells[i].Initialize(this, i);

                if (!IsLocked(i))
                    _skinCells[i].SetSkin(birdStaticData.Appearance.GetSkin(i));

                if (IsCurrentSkin(i))
                    _skinCells[i].SetSelect(true);
            }
        }

        public void ApplySkin(int skinIndex)
        {
            if (_progressData.BirdCurrentSkinIndex == skinIndex || IsLocked(skinIndex))
                return;

            _skinCells[_progressData.BirdCurrentSkinIndex].SetSelect(false);
            _skinCells[skinIndex].SetSelect(true);

            _progressData.BirdCurrentSkinIndex = skinIndex;
        }

        private bool IsLocked(int skinIndex)
            => skinIndex > _progressData.BirdOpenSkinsAmount - 1;

        private bool IsCurrentSkin(int skinIndex)
            => _progressData.BirdCurrentSkinIndex == skinIndex;
    }
}