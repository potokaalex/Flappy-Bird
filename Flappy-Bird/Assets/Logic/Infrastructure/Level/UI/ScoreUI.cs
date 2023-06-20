using FlappyBird.Gameplay;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private GameplayEcs _ecs;

        [Inject]
        private void Constructor(GameplayEcs ecs)
        {
            _ecs = ecs;
        }

        private void Start() 
            => _ecs.Contexts.input.scoreData.OnCurrentScoreChanged += UpdateScore;

        private void OnDisable()
            => _ecs.Contexts.input.scoreData.OnCurrentScoreChanged -= UpdateScore;

        private void UpdateScore(uint newScore)
            => _scoreText.text = newScore.ToString();
    }
}