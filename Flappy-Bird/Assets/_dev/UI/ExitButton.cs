public class ExitButton : ButtonBase
{
    private protected override void OnClick()
#if UNITY_EDITOR
            => UnityEditor.EditorApplication.isPlaying = false;
#else
        => UnityEngine.Application.Quit();
#endif
}