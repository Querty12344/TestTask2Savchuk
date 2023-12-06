using Infrastructure.StateMachine.GameStates;

namespace Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}