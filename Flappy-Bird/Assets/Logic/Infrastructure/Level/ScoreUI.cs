using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private DataProvider _data;

        [Inject]
        private void Constructor(DataProvider data)
        {
            data.Progress.Score.OnCurrentScoreChanged += UpdateScore;

            _data = data;
        }

        private void OnDestroy()
            => _data.Progress.Score.OnCurrentScoreChanged -= UpdateScore;

        private void UpdateScore(float newScore)
            => _scoreText.text = newScore.ToString();
    }
}