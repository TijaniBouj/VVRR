using UnityEngine;
using UnityEngine.AI;

public class EnemyActivation : MonoBehaviour
{
    public GameObject smallEnemy; // Reference to the small enemy GameObject
    private NavMeshAgent enemyAgent; // Reference to the NavMeshAgent component of the small enemy

    // Start is called before the first frame update
    void Start()
    {
        // Get the NavMeshAgent component from the small enemy GameObject
        enemyAgent = smallEnemy.GetComponent<NavMeshAgent>();

        // Ensure the small enemy is initially inactive
        smallEnemy.SetActive(false);
    }

    // Function to activate the small enemy and make it follow the same navigation path as the parent GameObject
    public void ActivateSmallEnemy()
    {
        // Activate the small enemy GameObject
        smallEnemy.SetActive(true);

        // Set the destination of the small enemy to the current destination of the parent GameObject
        enemyAgent.SetDestination(transform.position); // Set the destination to the current position of the parent GameObject
    }
}
