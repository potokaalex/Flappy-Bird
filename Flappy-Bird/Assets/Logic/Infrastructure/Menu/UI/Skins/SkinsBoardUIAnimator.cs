using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class SkinsBoardUIAnimator : AnimatorBase
    {
        private static readonly int _showAnimation = Animator.StringToHash("Show");
        private static readonly int _hideAnimation = Animator.StringToHash("Hide");

        public void PlayShowAnimation()
            => Animator.SetTrigger(_showAnimation);

        public void PlayHideAnimation()
            => Animator.SetTrigger(_hideAnimation);
    }
}