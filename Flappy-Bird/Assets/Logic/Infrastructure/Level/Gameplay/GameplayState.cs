using System.Threading.Tasks;
using FlappyBird.Gameplay;
using System;
using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly DataProvider _data;
        private readonly GameplayEcs _ecs;
        private readonly IGameLoop _gameLoop;

        public GameplayState(DataProvider data, GameplayEcs ecs, IGameLoop gameLoop)
        {
            _data = data;
            _ecs = ecs;
            _gameLoop = gameLoop;
        }

        private bool a = false;
        
        public async void Enter()
        {
            _gameLoop.OnFixedUpdate += Enter2;
            
            
            //await InputWaiting();
            
            //_ecs.StartSystems();
        }

        private void Enter2()
        {
            if (!_data.PlayerProgress.BirdFlyUpAction.WasPressedThisFrame())
                return;

            _gameLoop.OnFixedUpdate -= Enter2;

            //post waiting
            SendFlyUpEvent();
            _ecs.StartSystems();
        }

        private async Task InputWaiting()
        {
            //запуск цикла, при инпуте выходим из цикла и продолжаем выполнение стейта.

            //Task.Delay(3000);
            
            for (var i = 0; i < 10000; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(_gameLoop.FixedDeltaTime.Value));
                Debug.Log("132");
            }
            
            //_gameLoop.OnFixedUpdate += InputCheck;

            //await Task.Run(InputCheck);

            //_gameLoop.OnFixedUpdate -= InputCheck;
        }

        private async void InputCheck()
        {
            await Task.Delay(3000);
            
            //UnityEngine.Debug.Log("123");
            
            //if (!_data.PlayerProgress.BirdFlyUpAction.WasPressedThisFrame())
            //    await Task.Delay(3000);
        }

        public void Exit()
        {
            //_ecs.StopSystems();
            //stop anims
        }
        
        private void SendFlyUpEvent()
        {
            var entity = _ecs.Contexts.input.CreateEntity();

            entity.isFlyUp = true;
            entity.isEvent = true;
        }
    }
}