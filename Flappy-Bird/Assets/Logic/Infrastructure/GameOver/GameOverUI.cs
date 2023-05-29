using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private RetryButton _retryButton;
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(DataProvider data, IStateMachine stateMachine)
        {
            _retryButton.Initialize(data, stateMachine);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
        }
    }
}