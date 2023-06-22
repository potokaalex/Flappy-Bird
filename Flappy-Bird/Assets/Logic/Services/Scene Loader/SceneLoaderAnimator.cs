using UnityEngine;

namespace FlappyBird
{
    public class SceneLoaderAnimator : AnimatorBase
    {
        private static readonly int _closeAnimation = Animator.StringToHash("Close");
        private static readonly int _openAnimation = Animator.StringToHash("Open");
        
        public void PlayCloseAnimation() 
            => Animator.SetTrigger(_closeAnimation);

        public void PlayOpenAnimation()
            => Animator.SetTrigger(_openAnimation);
    }
}