using System.Collections.Generic;
using FlappyBird.Infrastructure;
using Entitas;

namespace FlappyBird.Gameplay.Basic
{
    public class GameOverStateSystem : ReactiveSystem<InputEntity>
    {
        private readonly IStateMachine _stateMachine;
        private readonly InputContext _inputContext;


        public GameOverStateSystem(InputContext inputContext, IStateMachine stateMachine) : base(inputContext)
        {
            _inputContext = inputContext;
            _stateMachine = stateMachine;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
            => context.CreateCollector(InputMatcher.GameOverState.Added());

        protected override bool Filter(InputEntity inputEntity)
            => true;

        protected override void Execute(List<InputEntity> entities)
        {
            //_inputContext.isGameOver = false;
            //_inputContext.isGameOverState = false;
            
            _stateMachine.SwitchTo<GameOverState>();
        }
    }
}