namespace FlappyBird
{
    public class LoadingState : IState<SceneLoadingConfiguration>
    {
        private ISceneLoader _sceneLoader;

        public LoadingState(ISceneLoader sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Enter(SceneLoadingConfiguration config)
            => _sceneLoader.LoadScene(config);
    }
}
