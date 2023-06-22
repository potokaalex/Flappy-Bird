using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.Infrastructure
{
    public class ScoreOnBoardUI : MonoBehaviour
    {
        [SerializeField] private Text _currentScore;
        [SerializeField] private Text _maxScore;

        public void ShowScore(uint currentScore, uint maxScore)
        {
            _currentScore.text = currentScore.ToString();
            _maxScore.text = maxScore.ToString();
        }
    }
}