using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(SceneLoadingConfiguration config)
            => SceneManager.LoadScene(config.SceneName, config.LoadSceneMode);
    }
}
