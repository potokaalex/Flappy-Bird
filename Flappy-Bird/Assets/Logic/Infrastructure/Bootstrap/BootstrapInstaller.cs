using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private DataProvider _dataProvider;

        public override void InstallBindings()
        {
            BindStateMachineInitialize(); //
            BindDataProvider();
            BindStateMachine();
            BindStateFactory();
            BindSceneLoader();
            BindGameLoop();
        }

        private void BindDataProvider()
        {
            Container
                .Bind<DataProvider>()
                .FromInstance(_dataProvider)
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

        private void BindGameLoop()
        {
            Container
                .Bind<IGameLoop>()
                .To<GameLoop>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindStateMachineInitialize()
        {
            Container
                .BindInterfacesTo<StateMachineInitialize>()
                .AsSingle();
        }
    }
}