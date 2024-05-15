using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] // Ensure that the NavMeshAgent component is attached
public class RandomMovement : MonoBehaviour
{
    public float range = 10f; // Radius of the movement area
    public float movementSpeed = 1.5f; // Speed of movement
    public float newDestinationInterval = 3f; // Interval to choose a new random destination
    public Transform centrePoint; // Centre of the movement area

    private NavMeshAgent agent;
    private Vector3 randomDestination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = movementSpeed;
        StartCoroutine(UpdateDestination());
    }

    IEnumerator UpdateDestination()
    {
        while (true)
        {
            SetRandomDestination();
            yield return new WaitForSeconds(newDestinationInterval);
        }
    }

    void SetRandomDestination()
    {
        Vector3 point;
        if (RandomPoint(centrePoint.position, range, out point))
        {
            Debug.DrawLine(transform.position, point, Color.green, 1.0f); // Visualize the movement path
            agent.SetDestination(point);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centrePoint.position, range); // Visualize the movement area
        if (randomDestination != Vector3.zero)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(randomDestination, 0.5f); // Visualize the random destination
        }
    }
}
