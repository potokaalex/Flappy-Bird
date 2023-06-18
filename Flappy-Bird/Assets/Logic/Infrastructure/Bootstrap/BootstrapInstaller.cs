using FlappyBird.Gameplay;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerProgress();
            BindDataProvider();
            BindStateMachine();
            BindStateFactory();
            BindSceneLoader();
            BindGameplayEcs();
            BindGameLoop();
            
        }

        private void BindPlayerProgress()
        {
            Container
                .Bind<IPlayerProgress>()
                .To<PlayerProgress>()
                .AsSingle();
        }
        
        private void BindDataProvider()
        {
            Container
                .Bind<IDataProvider>()
                .To<DataProvider>()
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