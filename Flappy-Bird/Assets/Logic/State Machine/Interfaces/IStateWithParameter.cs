namespace FlappyBird
{
    public interface IState<in T> : IState where T : IStateParameter
    {
        public void Enter(T parameter);
    }
}