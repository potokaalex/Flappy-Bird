namespace FlappyBird.Infrastructure
{
    public class MenuState : IState
    {
        private readonly IPlayerProgress _playerProgress;
        private readonly IDataProvider _dataProvider;

        public MenuState(IDataProvider dataProvider, IPlayerProgress playerProgress)
        {
            _dataProvider = dataProvider;
            _playerProgress = playerProgress;
        }

        public void Enter()
            => _dataProvider.Set(_playerProgress.LoadData());

        public void Exit()
            => _playerProgress.SaveData(_dataProvider.Get<ProgressData>());
    }
}