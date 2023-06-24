using UnityEngine.SceneManagement;

namespace FlappyBird.Infrastructure
{
    public class MenuLoadingState : IState
    {
        private const string MenuSceneName = "Menu";

        private readonly ISceneLoader _sceneLoader;

        public MenuLoadingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter()
            => _sceneLoader.LoadScene(MenuSceneName, LoadSceneMode.Single);
    }
}