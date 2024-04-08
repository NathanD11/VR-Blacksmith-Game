using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    public Transform startingPosition;  // Starting position of the ball
    public GameObject hammer;  // The hammer object that will destroy the ball
    public GameObject invisibleObject;  // The invisible object that will reset the ball

    public bool isTouchingGround;  // Flag to track if the ball is touching the ground
    public bool isHitByHammer;  // Flag to track if the ball is hit by the hammer

    public int score;  // Variable to keep track of the score
    public TextMeshProUGUI scoreText;  // Text display for the score

    public float hammerVelocityThreshold = 5f; // Minimum velocity required for the hammer to count as a collision

    void Update()
    {
        scoreText.text = "Points: " + score.ToString();
        // Check if the ball is touching the ground
        if (isTouchingGround)
        {
            // Check if the ball is hit by the hammer
            if (isHitByHammer)
            {
                // Reset the ball to its starting position
                ResetBall();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("first") && isHitByHammer)
        {
            ResetBall();
        }

        // Check if the ball is touching the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }

        if (other.gameObject.CompareTag("Reset"))
        {
            ResetBall();
        }

        // Check if the other object is the hammer and if it's moving fast enough
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if (other.gameObject == hammer && isTouchingGround == true && otherRigidbody.velocity.magnitude >= hammerVelocityThreshold)
        {
            isHitByHammer = true;
            score++;
            scoreText.text = "Points: " + score.ToString();
        }

        // Check if the ball is hit by the invisible wall
        if (other.gameObject == invisibleObject)
        {
            ResetBall();
        }
    }

    public void ResetBall()
    {
        transform.position = startingPosition.position;
        isTouchingGround = false;
        isHitByHammer = false;
    }

    public void SetHitByHammer(bool hit)
    {
        isHitByHammer = hit;
    }
}