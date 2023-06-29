namespace FlappyBird.Infrastructure
{
    public class ExitState : IState
    {
        public void Enter()
#if UNITY_EDITOR
            => UnityEditor.EditorApplication.isPlaying = false;
#else
            => UnityEngine.Application.Quit();
#endif
    }
}