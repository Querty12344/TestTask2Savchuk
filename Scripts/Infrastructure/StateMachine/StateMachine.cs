using System;
using System.Collections.Generic;
using Infrastructure.StateMachine.GameStates;

namespace Infrastructure.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        public StateMachine(ResourceLoadingState resourceState, LoadLevelState loadLevelState,
            GameLoopState gameLoopState)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(ResourceLoadingState)] = resourceState,
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(GameLoopState)] = gameLoopState
            };
        }

        public void Enter<TState>() where TState : IState
        {
            var next = _states[typeof(TState)];
            next.Enter(this);
        }
    }
}