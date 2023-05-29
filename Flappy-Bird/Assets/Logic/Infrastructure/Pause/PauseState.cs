namespace FlappyBird.Infrastructure
{
    public class PauseState : IState
    {
        private readonly DataProvider _data;

        public PauseState(DataProvider data)
            => _data = data;

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}