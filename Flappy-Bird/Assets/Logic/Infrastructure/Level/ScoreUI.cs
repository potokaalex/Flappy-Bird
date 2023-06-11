using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private IDataProvider _data;

        [Inject]
        private void Constructor(IDataProvider data)
        {
            _data = data;
            
            _data.Get<PlayerProgress>().Score.OnCurrentScoreChanged += UpdateScore;
        }

        private void OnDestroy()
            => _data.Get<PlayerProgress>().Score.OnCurrentScoreChanged -= UpdateScore;

        private void UpdateScore(float newScore)
            => _scoreText.text = newScore.ToString();
    }
}