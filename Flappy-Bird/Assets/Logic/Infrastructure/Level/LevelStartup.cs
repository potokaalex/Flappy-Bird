using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Bird;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class LevelStartup : MonoBehaviour
    {
        [SerializeField] private BirdSceneData _birdData;
        [SerializeField] private PipesSceneData _pipesData;
        [SerializeField] private GrassSceneData _grassData;
        [SerializeField] private LevelSceneData _sceneData;

        private IStateMachine _stateMachine;
        private IDataProvider _dataProvider;

        [Inject]
        private void Constructor(IDataProvider dataProvider, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _dataProvider = dataProvider;
        }

        private void Start()
        {
            _dataProvider.Set(_birdData, _pipesData, _grassData, _sceneData);
            
            _stateMachine.SwitchTo<PreGameplayState>();
        }
    }
}