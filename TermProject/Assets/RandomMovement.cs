using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public float waitTime = 2f;
    private NavMeshAgent agent;
    private float waitTimer;
    public GameObject mazeObject;
    private Bounds mazeBounds;
    public float moveRadius = 10f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.Log("NavMeshAgent is missing from the object!");
            enabled = false;
            return;
        }

        if (mazeObject == null)
        {
            Debug.Log("Maze object is not assigned!");
            enabled = false;
            return;
        }

        mazeBounds = mazeObject.GetComponent<Renderer>().bounds;

        MoveToRandomPoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTimer += Time.deltaTime;

            // Wait at the current position for a while before moving again
            if (waitTimer >= waitTime)
            {
                MoveToRandomPoint();
                waitTimer = 0;
            }
        }
    }

    void MoveToRandomPoint()
    {
        Vector3 randomPoint;

        // Retry until a valid point within bounds is found
        do
        {
            randomPoint = GetRandomPointWithinRadius(transform.position, moveRadius);
        }
        while (!IsWithinMazeBounds(randomPoint));

        if (randomPoint != Vector3.zero)
        {
            agent.SetDestination(randomPoint);
        }
    }

    Vector3 GetRandomPointWithinRadius(Vector3 origin, float radius)
    {
        int maxAttempts = 10; // Limit the number of attempts
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += origin;
            randomDirection.y = origin.y;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
            {
                if (IsWithinMazeBounds(hit.position))
                {
                    return hit.position;
                }
            }
        }

        Debug.LogWarning("Failed to find a valid random point after multiple attempts.");
        return new Vector3(27,1,20); // Default to zero if no valid point is found
    }

    bool IsWithinMazeBounds(Vector3 point)
    {
        return mazeBounds.Contains(point);
    }
}
