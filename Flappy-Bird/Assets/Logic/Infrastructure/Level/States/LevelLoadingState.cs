using UnityEngine.SceneManagement;

namespace FlappyBird.Infrastructure
{
    public class LevelLoadingState : IState
    {
        private const string LevelSceneName = "Level";

        private readonly ISceneLoader _sceneLoader;

        public LevelLoadingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter()
            => _sceneLoader.LoadScene(LevelSceneName, LoadSceneMode.Single);
    }
}