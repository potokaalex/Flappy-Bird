using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class GameOverUI : MonoBehaviour
    {
        private static readonly int _openAnimation = Animator.StringToHash("Open");
        [SerializeField] private Animator _gameOverUIAnimator;
        
        public void PlayOpenAnimation() 
            => _gameOverUIAnimator.SetTrigger(_openAnimation);
    }
}