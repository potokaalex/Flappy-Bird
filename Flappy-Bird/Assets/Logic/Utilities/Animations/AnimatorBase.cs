using System.Collections;
using UnityEngine;
using System;

namespace FlappyBird
{
    public abstract class AnimatorBase : MonoBehaviour
    {
        [SerializeField] private protected Animator Animator;

        public void StartActionAfterCurrentAnimation(Action action)
            => StartCoroutine(ActionAfterAnimation(Animator.GetCurrentAnimatorStateInfo(0), action));

        private IEnumerator ActionAfterAnimation(AnimatorStateInfo stateInfo, Action action)
        {
            yield return new WaitForSeconds(stateInfo.length);

            action?.Invoke();
        }
    }
}