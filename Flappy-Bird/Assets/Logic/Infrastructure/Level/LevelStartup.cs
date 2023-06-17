using UnityEngine.InputSystem;
using FlappyBird.Gameplay;
using FlappyBird.Gameplay.Core.Bird;
using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private GameOverStateConfiguration _gameOverConfiguration;

        [SerializeField] private BirdSceneData _birdData;
        [SerializeField] private PipesSceneData _pipesData;
        [SerializeField] private GrassSceneData _grassData;

        private IStateMachine _stateMachine;
        private IDataProvider _data;

        [Inject]
        private void Constructor(IDataProvider dataProvider, GameplayEcs ecs, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _data = dataProvider;
        }

        private void Start()
        {
            _data.Get<GameOverStateConfiguration>().GameOverUI = _gameOverConfiguration.GameOverUI;
            _data.Get<GameOverStateConfiguration>().GameplayUI = _gameOverConfiguration.GameplayUI;

            InitSceneData();

            _stateMachine.SwitchTo<PreGameplayState>();
        }

        private void InitSceneData()
        {
            _data.Set(_birdData, _pipesData, _grassData);
        }
    }
}