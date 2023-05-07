using FlappyBird.Gameplay.Bird;
using UnityEngine.InputSystem;
using UnityEngine;

public class LevelStartup : MonoBehaviour
{
    [SerializeField] private BirdConfiguration _birdConfiguration;
    [SerializeField] private GameLoop _gameLoop;

    [SerializeField] private InputAction _birdFlyUpAction;//

    private void Start()
    {
        var ecs = new LevelEcs(_gameLoop);

        ecs.InitializeConfigurations(_birdConfiguration);
        ecs.InitializeEntities();
        ecs.InitializeSystems(_birdConfiguration.FlyUpAction);
    }
}
