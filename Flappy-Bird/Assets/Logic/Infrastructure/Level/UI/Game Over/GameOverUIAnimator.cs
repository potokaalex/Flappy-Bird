using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class GameOverUIAnimator : AnimatorBase
    {
        private static readonly int _openAnimation = Animator.StringToHash("Open");

        public void PlayOpenAnimation()
            => Animator.SetTrigger(_openAnimation);
    }
}