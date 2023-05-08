using Entitas;

namespace FlappyBird.Extensions
{
    public class BreakableSystems : Systems
    {
        public bool IsBreak { get; set; }

        public override void Initialize()
        {
            IsBreak = false;
            base.Initialize();
        }

        public override void Execute()
        {
            for (int i = 0; i < _executeSystems.Count; i++)
            {
                if (IsBreak)
                    break;

                _executeSystems[i].Execute();
            }
        }
    }
}
