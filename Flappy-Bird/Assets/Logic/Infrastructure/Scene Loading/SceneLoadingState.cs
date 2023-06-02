namespace FlappyBird
{
    public class SceneLoadingState : IState<SceneLoadingConfiguration>
    {
        private readonly ISceneLoader _sceneLoader;

        public SceneLoadingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter(SceneLoadingConfiguration config)
            => _sceneLoader.LoadScene(config);
    }
}