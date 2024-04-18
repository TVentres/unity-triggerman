using UnityEngine;

public class ChaseState : IAIState
{
    private AIStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;
    private float detectionRadius = 50f; // Example detection radius

    // Update the constructor to accept AIStateMachine and NavMeshAgent
    public ChaseState(AIStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Enter()
    {
        Debug.Log("Entering Chase State");
    }

    public void Execute()
    {
        // Check if the player is out of detection range
        if (Vector3.Distance(stateMachine.agent.transform.position, playerTransform.position) > detectionRadius)
        {
            // Transition to PatrolState
            stateMachine.SetState(new PatrolState(stateMachine, stateMachine.agent));
        }

        else {

        }

        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

    public void Exit()
    {
    }
}
