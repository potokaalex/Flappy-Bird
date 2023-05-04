using UnityEngine;
using FlappyBird.Gameplay.Bird;

public class LevelStartup : MonoBehaviour
{
    [SerializeField] private BirdConfiguration _birdConfiguration;
    [SerializeField] private GameLoop _gameLoop;

    private void Start()
    {
        var ecs = new LevelEcs(_gameLoop);

        ecs.InitializeConfigurations(_birdConfiguration);
        ecs.InitializeEntities();
        ecs.InitializeSystems();
    }
}
