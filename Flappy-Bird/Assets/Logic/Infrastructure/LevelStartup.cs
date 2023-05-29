using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private PlayerProgressConfiguration _progressConfiguration;
        [SerializeField] private GameOverStateConfiguration _gameOverConfiguration;
        [SerializeField] private GameplayEcsConfiguration _gameplayEcsConfiguration;
        
        private IStateMachine _stateMachine;
        private DataProvider _data;
        private GameplayEcs _ecs;

        [Inject]
        private void Constructor(DataProvider dataProvider,GameplayEcs ecs,IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _data = dataProvider;
            _ecs = ecs;
        }

        private void Start()
        {
            _data.PlayerProgress.Initialize(_progressConfiguration);
            _ecs.Initialize(_gameplayEcsConfiguration);
            _stateMachine.SwitchTo<GameplayState>();
        }
    }
}