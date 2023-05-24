using UnityEngine.UI;
using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        public void Initialize(DataProvider data)
            => data.PlayerProgress.Score.OnCurrentScoreChanged += UpdateScore;

        private void UpdateScore(float newScore)
            => _scoreText.text = newScore.ToString();
    }
}