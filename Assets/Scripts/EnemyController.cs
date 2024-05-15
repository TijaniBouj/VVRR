using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Function to handle collision with the ball
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Ball"
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy the enemy GameObject
            Destroy(gameObject);

            // Destroy the ball GameObject
            Destroy(collision.gameObject);
        }
    }
}
