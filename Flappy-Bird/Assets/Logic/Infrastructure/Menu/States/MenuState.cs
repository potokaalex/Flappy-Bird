namespace FlappyBird.Infrastructure
{
    public class MenuState : IState
    {
        private readonly IPlayerProgress _playerProgress;

        public MenuState(IPlayerProgress playerProgress)
            => _playerProgress = playerProgress;

        public void Enter()
            => _playerProgress.LoadData();

        public void Exit()
            => _playerProgress.SaveData();
    }
}