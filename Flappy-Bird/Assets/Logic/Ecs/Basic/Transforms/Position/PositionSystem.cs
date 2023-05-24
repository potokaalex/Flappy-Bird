﻿using Entitas;

namespace FlappyBird.Ecs.Basic.Transforms
{
    public class PositionSystem : IExecuteSystem
    {
        private readonly IGroup<LevelEntity> _movables;

        public PositionSystem(LevelContext context)
        {
            _movables = context.GetGroup(
                LevelMatcher.AllOf(
                    LevelMatcher.LinkToGameObject, LevelMatcher.Position));
        }

        public void Execute()
        {
            foreach (var movable in _movables)
                movable.linkToGameObject.GameObject.transform.position = movable.position.Value;
        }
    }
}