using System.Collections.Generic;
using Entitas;

namespace FlappyBird
{
    public class GameplaySystems : Systems, ISwitchableSystem, IFactorySystem
    {
        private readonly List<ISwitchableSystem> _switchableSystems = new();
        private readonly List<IFactorySystem> _factorySystems = new();

        public override Systems Add(ISystem system)
        {
            if (system is ISwitchableSystem switchableSystem)
                _switchableSystems.Add(switchableSystem);

            if (system is IFactorySystem factorySystem)
                _factorySystems.Add(factorySystem);

            return base.Add(system);
        }

        public virtual void Start(IGameLoop gameLoop)
        {
            foreach (var switchableSystem in _switchableSystems)
                switchableSystem.Start(gameLoop);
        }

        public virtual void Stop(IGameLoop gameLoop)
        {
            foreach (var switchableSystem in _switchableSystems)
                switchableSystem.Stop(gameLoop);
        }

        public virtual void CreateEntities()
        {
            foreach (var factorySystem in _factorySystems)
                factorySystem.CreateEntities();
        }

        public virtual void RemoveEntities()
        {
            foreach (var factorySystem in _factorySystems)
                factorySystem.RemoveEntities();
        }
    }
}