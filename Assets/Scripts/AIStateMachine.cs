using UnityEngine;
using UnityEngine.AI; // This is necessary for NavMeshAgent


public class AIStateMachine : MonoBehaviour
{
    private IAIState currentState;
    public NavMeshAgent agent; // Reference to the NavMeshAgent component

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // Ensure this component is attached to the same GameObject

        // If you're directly instantiating states, do it like this:
        // This assumes PatrolState's constructor requires AIStateMachine and NavMeshAgent parameters
        var patrolState = new PatrolState(this, agent);

        // Example of setting the initial state to PatrolState
        SetState(patrolState);
    }

    public void SetState(IAIState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Execute();
    }
}
