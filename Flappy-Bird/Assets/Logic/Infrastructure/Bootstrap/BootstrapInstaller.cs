using Zenject;

namespace FlappyBird.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindDataProvider();
            BindStateMachine();
            BindStateFactory();
            BindSceneLoader();
            BindGameplayEcs();
            BindGameLoop();
        }

        private void BindDataProvider()
        {
            Container
                .Bind<DataProvider>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .To<StateMachine>()
                .AsSingle();
        }

        private void BindStateFactory()
        {
            Container
                .Bind<IStateFactory>()
                .FromInstance(new StateFactory(Container))
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindGameplayEcs()
        {
            Container
                .Bind<GameplayEcs>()
                .AsSingle();
        }

        private void BindGameLoop()
        {
            Container
                .Bind<IGameLoop>()
                .To<GameLoop>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}