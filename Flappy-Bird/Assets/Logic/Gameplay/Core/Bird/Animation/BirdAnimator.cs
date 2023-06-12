using UnityEngine;

namespace FlappyBird.Gameplay.Core.Bird
{
    public readonly struct BirdAnimator
    {
        private static readonly int _flyUpStateHash = Animator.StringToHash("FlyUp");
        private static readonly int _fallDownStateHash = Animator.StringToHash("FallDown");

        private readonly Animator _animator;

        public BirdAnimator(Animator animator)
            => _animator = animator;

        public void PlayFlyUp()
            => _animator.SetTrigger(_flyUpStateHash);

        public void PlayFallDown()
            => _animator.SetTrigger(_fallDownStateHash);
    }
}