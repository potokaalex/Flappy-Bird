using Entitas;
using System;
using UnityEngine;

namespace FlappyBird.Gameplay.Bird
{
    public class RotationSystem : IExecuteSystem
    {
        private IGroup<LevelEntity> _birdEntities;

        public RotationSystem(LevelContext context) 
            => _birdEntities = context.GetGroup(LevelMatcher.Bird);

        //FallAngularVelocity
        //FlyUpAngularVelocity
        //max rot
        //min rot

        public void Execute()
        {
            /*
            if (velocity.y > 0)//взлетаем
            {
                rotation += 600 * Time.fixedDeltaTime;

                if (rotation > 20)
                {
                    rotation = 20;
                }
            }

            if (isFalling() || !isAlive)//падаем
            {
                rotation -= 480 * Time.fixedDeltaTime;

                if (rotation < -90)
                {
                    rotation = -90;
                }
            }
            */
        }
    }
}
