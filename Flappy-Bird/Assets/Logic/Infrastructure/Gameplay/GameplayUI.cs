using System.Globalization;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private PauseToggle _pauseToggle;
        [SerializeField] private ScoreUI _scoreUI;
        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(DataProvider data, IStateMachine stateMachine)
        {
            _pauseToggle.Initialize(stateMachine);
            _scoreUI.Initialize(data);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}