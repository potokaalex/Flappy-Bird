using System.Collections;
using UnityEngine;
using System;

namespace FlappyBird
{
    public class SceneLoaderAnimator : MonoBehaviour
    {
        private static readonly int _closeAnimation = Animator.StringToHash("Close");
        private static readonly int _openAnimation = Animator.StringToHash("Open");

        [SerializeField] private Animator _animator;

        public void PlayCloseAnimation(Action afterAnimation)
        {
            _animator.SetTrigger(_closeAnimation);

            StartCoroutine(ActionAfterAnimation(afterAnimation));
        }
        
        public void PlayOpenAnimation() 
            => _animator.SetTrigger(_openAnimation);

        private IEnumerator ActionAfterAnimation(Action action)
        {
            var currentAnimation = _animator.GetCurrentAnimatorStateInfo(0);
            
            yield return new WaitForSeconds(currentAnimation.length);

            action?.Invoke();
        }
    }
}