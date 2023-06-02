using FlappyBird.Gameplay;

namespace FlappyBird.Infrastructure
{
    public class GameplayState : IState
    {
        private readonly DataProvider _data;
        private readonly GameplayEcs _ecs;

        public GameplayState(DataProvider data, GameplayEcs ecs)
        {
            _data = data;
            _ecs = ecs;
        }

        public void Enter()
        {
            _ecs.StartSystems();
            //start grass anim
        }

        public void Exit()
        {
            //_ecs.StopSystems();
            //stop anims
        }
    }
}