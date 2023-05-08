namespace FlappyBird.StateMachine
{
    public interface IState<T> : IState where T : IStateParameter
    {
        public void Enter(T parameter);
    }
}
