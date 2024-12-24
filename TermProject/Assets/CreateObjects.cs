using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CreateObjects : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 10;
    public Vector2 gridSize = new(20, 10);
    public float spacing = 0.5f;
    public Vector3 startPoint = new(-20, 1.15f, 1);
    public float groundZScale = 40;
    private NavMeshAgent[] agents;
    private NavMeshPath[] paths;
    public GameObject movingTarget;
    private bool pathsReady = false;
    public float updateInterval = 0.1f;

    void Start()
    {
        agents = new NavMeshAgent[numberOfObjects];
        paths = new NavMeshPath[numberOfObjects];
        GenerateObjects();
        StartCoroutine(UpdateAgentDestinations());
    }

    void GenerateObjects()
    {
        float prefabWidth = prefab.GetComponent<Renderer>().bounds.size.x;
        float prefabDepth = prefab.GetComponent<Renderer>().bounds.size.z;

        int usableRows = Mathf.FloorToInt(groundZScale / (prefabDepth + spacing));

        for (int i = 0; i < numberOfObjects; i++)
        {
            if (i / (int)gridSize.x >= usableRows)
            {
                Debug.LogWarning("Not enough space on the ground plane to fit all objects.");
                break;
            }

            float x = startPoint.x - (i / (int)gridSize.y) * (prefabWidth + spacing);
            float z = startPoint.z + (i % (int)gridSize.y) * (prefabDepth + spacing);

            Vector3 position = new(x, startPoint.y, z);

            GameObject instance = Instantiate(prefab, position, Quaternion.identity);

            NavMeshAgent agent = instance.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agents[i] = agent;
                paths[i] = new NavMeshPath();
            }
        }
    }

    IEnumerator UpdateAgentDestinations()
    {
        while (true)
        {
            if (movingTarget != null)
            {
                foreach (var agent in agents)
                {
                    if (agent != null)
                    {
                        agent.SetDestination(movingTarget.transform.position);
                    }
                }
            }

            yield return new WaitForSeconds(updateInterval);
        }
    }

    void CalculatePaths()
    {
        bool allPathsCalculated = true;

        for (int i = 0; i < agents.Length; i++)
        {
            if (agents[i] != null && movingTarget != null)
            {
                if (NavMesh.SamplePosition(movingTarget.transform.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
                {
                    Vector3 targetOnNavMesh = hit.position;
                    if (!agents[i].CalculatePath(targetOnNavMesh, paths[i]))
                    {
                        allPathsCalculated = false;
                    }
                }
                else
                {
                    allPathsCalculated = false;
                }
            }
        }

        pathsReady = allPathsCalculated;
    }

    void MoveAgents()
    {
        for (int i = 0; i < agents.Length; i++)
        {
            if (agents[i] != null && paths[i] != null && paths[i].status == NavMeshPathStatus.PathComplete)
            {
                agents[i].SetPath(paths[i]);
            }
        }

        pathsReady = false;
    }
}
