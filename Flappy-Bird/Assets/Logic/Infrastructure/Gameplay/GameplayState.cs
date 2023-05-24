﻿namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly DataProvider _data;

        public GameplayState(DataProvider data)
            => _data = data;

        public void Enter()
        {
            _data.Ecs.GameplaySystems.Initialize();
        }

        public void Exit()
        {
            _data.Ecs.GameplaySystems.Dispose();
        }
    }
}