using UnityEngine.UI;
using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class BirdOnBoardUIAnimator : AnimatorBase
    {
        private static readonly int _showAnimation = Animator.StringToHash("Show");

        [SerializeField] private Image _birdImage;

        public void PlayShowAnimation(Sprite birdSprite)
        {
            _birdImage.sprite = birdSprite;
            Animator.SetTrigger(_showAnimation);
        }
    }
}