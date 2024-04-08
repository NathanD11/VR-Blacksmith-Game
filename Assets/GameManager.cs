using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;  // Reference to the Ball script attached to the ball object
    public GameObject hammer;  // Reference to the hammer object

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the hammer object
        if (collision.gameObject.CompareTag("Hammer"))
        {
            // Set the isHitByHammer flag to true in the ball script
            ball.isHitByHammer = true;

            // Restart the game
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reset the ball
        ball.ResetBall();

        // Reset the hammer position
        hammer.transform.position = new Vector3(0f, 0f, 10f);
    }
}