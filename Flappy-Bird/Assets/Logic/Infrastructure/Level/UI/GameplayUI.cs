using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class GameplayUI : MonoBehaviour
    {
        private static readonly int _closeAnimation = Animator.StringToHash("Close");
        private static readonly int _openAnimation = Animator.StringToHash("Open");
        [SerializeField] private Animator _gameplayUIAnimator;
        
        public void PlayOpenAnimation() 
            => _gameplayUIAnimator.SetTrigger(_openAnimation);
        
        public void PlayCloseAnimation() 
            => _gameplayUIAnimator.SetTrigger(_closeAnimation);
    }
}