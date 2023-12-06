namespace Infrastructure.StateMachine.GameStates
{
    public interface IState
    {
        void Enter(IStateMachine stateMachine);
    }
}