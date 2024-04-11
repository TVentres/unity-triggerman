using UnityEngine;
using System.Linq; // For LINQ queries

public class PatrolState : IAIState
{
    private AIStateMachine stateMachine;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private Transform playerTransform;
    private float detectionRadius = 30f; // Example detection radius
    public bool IsChasing;

    public PatrolState(AIStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").Select(obj => obj.transform).ToArray();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Enter()
    {
        waypointIndex = 0;
        stateMachine.agent.SetDestination(waypoints[waypointIndex].position);
        Debug.Log("Entering Patrol State");
    }

    public void Execute()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(stateMachine.agent.transform.position, playerTransform.position) <= detectionRadius)
        {
            // Transition to ChaseState
            stateMachine.SetState(new ChaseState(stateMachine, stateMachine.agent));
        }
        else
        {
            // Continue patrolling if the player is not detected
            if (stateMachine.agent.remainingDistance < 0.5f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                stateMachine.agent.SetDestination(waypoints[waypointIndex].position);
            }
        }
    }

    public void Exit()
    {
        // Cleanup or resetting logic when exiting PatrolState
    }
}
