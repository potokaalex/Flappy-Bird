using UnityEngine.UI;
using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private DataProvider _data;

        public void Initialize(DataProvider data)
        {
            data.PlayerProgress.Score.OnCurrentScoreChanged += UpdateScore;
            
            _data = data;
        }

        private void UpdateScore(float newScore)
            => _scoreText.text = newScore.ToString();

        private void OnDestroy()
            => _data.PlayerProgress.Score.OnCurrentScoreChanged -= UpdateScore;
    }
}