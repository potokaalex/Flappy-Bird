using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class GameplayUI : MonoBehaviour
    {
        private static readonly int _closeAnimation = Animator.StringToHash("Close");
        [SerializeField] private Animator _gameplayUIAnimator;
        
        public void PlayCloseAnimation() 
            => _gameplayUIAnimator.SetTrigger(_closeAnimation);
    }
}