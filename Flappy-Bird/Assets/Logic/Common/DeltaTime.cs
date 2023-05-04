namespace FlappyBird.Common
{
    public class DeltaTime//GameLoop ?
    {
        public float Value { get; private set; }

        public void SetValue(float newValue)
            => Value = newValue;
    }
}
