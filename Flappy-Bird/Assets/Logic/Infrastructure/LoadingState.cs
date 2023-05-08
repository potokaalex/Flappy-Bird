using UnityEngine.SceneManagement;
using FlappyBird.StateMachine;

public class LoadingState : IState<SceneLoadingConfiguration>
{
    public void Enter(SceneLoadingConfiguration config)
        => SceneManager.LoadScene(config.SceneName, config.LoadSceneMode);
}
