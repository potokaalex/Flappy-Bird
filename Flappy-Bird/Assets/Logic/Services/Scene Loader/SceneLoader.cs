using UnityEngine.SceneManagement;
using UnityEngine;

namespace FlappyBird
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoaderAnimator _animator;

        public void LoadScene(string sceneName, LoadSceneMode loadMode)
        {
            var loadingOperation = SceneManager.LoadSceneAsync(sceneName, loadMode);
            loadingOperation.allowSceneActivation = false;

            _animator.PlayCloseAnimation();
            
            _animator.StartActionAfterCurrentAnimation(() =>
            {
                loadingOperation.allowSceneActivation = true;
                _animator.PlayOpenAnimation();
            });
        }
    }
}