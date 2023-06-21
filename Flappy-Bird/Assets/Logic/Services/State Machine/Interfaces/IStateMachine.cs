namespace FlappyBird
{
    public interface IStateMachine
    {
        public void Initialize(params IState[] states);

        public IState GetCurrentState();
        
        public void SwitchTo<StateType>()
            where StateType : IState;
    }
}