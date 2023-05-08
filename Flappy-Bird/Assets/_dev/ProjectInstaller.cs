using Zenject;
using System.Collections.Generic;
using UnityEngine;
using System;
using FlappyBird.StateMachine;
using FlappyBird.Infrastructure;
using FlappyBird.Gameplay.Bird;
using System.ComponentModel;

//Хочу заменить обычним инсталлером !
public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private DataProvider _dataProvider;

    //SceneLoader
    //DataProvider
    //Save-loader
    //State-machine

    public override void InstallBindings()
    {
        BindGameLoop();
        BindDataProvider();
        BindStateMachine();
        BindStateFactory();
        BindStateMachineInitialize();
    }

    private void BindGameLoop()
    {
        Container
            .Bind<GameLoop>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
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

    private void BindStateMachineInitialize()
    {
        Container
            .BindInterfacesAndSelfTo<StateMachineInitialize>()
            .AsSingle();
    }
}

public class StateMachineInitialize : IInitializable
{
    private IStateMachine _stateMachine;
    private IStateFactory _stateFactory;

    public StateMachineInitialize(IStateMachine stateMachine, IStateFactory stateFactory)
    {
        _stateMachine = stateMachine;
        _stateFactory = stateFactory;
    }

    public void Initialize()
    {
        _stateMachine.Initialize(
            _stateFactory.Create<LevelState>(),
            _stateFactory.Create<LoadingState>());
    }
}

//Нужно точно сохранять и загружать данные.

//Сохранять:
//максимальный score
//баланс (score)
//купленные скини.
//настройки: бинды, звуки(вкл/выкл), действующие скины


[Serializable]
public class DataProvider//Статические данные для всей игры!
{
    public BirdConfiguration BirdConfiguration;

    public SceneLoadingConfiguration LevelLoadingConfiguration;
}