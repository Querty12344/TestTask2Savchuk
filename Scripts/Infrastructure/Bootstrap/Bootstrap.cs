using Infrastructure.CoroutineRunner;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace Infrastructure.Bootstrap
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private IStateMachine _stateMachine;

        private void Start()
        {
            DontDestroyOnLoad(this);
            _stateMachine.Enter<ResourceLoadingState>();
        }

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}