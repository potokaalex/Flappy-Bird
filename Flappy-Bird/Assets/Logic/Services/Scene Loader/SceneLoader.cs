using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName, LoadSceneMode loadMode)
            => SceneManager.LoadScene(sceneName, loadMode);
    }
}