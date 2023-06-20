using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public interface ISceneLoader
    {
        public void LoadScene(string sceneName, LoadSceneMode loadMode);
    }
}
