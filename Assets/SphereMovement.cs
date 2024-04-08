using UnityEngine;
using System.Collections;

public class SphereMovement : MonoBehaviour {

    public float distanceToMove = 5f; // Distance to move to the right
    public float moveSpeed = 2f; // Speed at which to move
    public float resetTime = 2f; // Time to wait before resetting position
    private Vector3 startPosition; // Initial position of sphere

    void Start () {
        startPosition = transform.position;
        StartCoroutine(MoveAndReset());
    }

    IEnumerator MoveAndReset() {
        Vector3 previousPosition = startPosition;
        float distanceMoved = 0f; // declare and initialize distanceMoved here
        while (true) {
            // Move to the right
            while (distanceMoved < distanceToMove) {
                float distanceThisFrame = moveSpeed * Time.deltaTime;
                transform.Translate(distanceThisFrame, 0f, 0f);
                distanceMoved += distanceThisFrame;
                yield return null;
            }

            // Wait for resetTime seconds
            yield return new WaitForSeconds(resetTime);

            // Check if the sphere has reached the starting position
            if (transform.position == startPosition) {
                // If the sphere has reached the starting position, reset its position to the previous position
                transform.position = previousPosition;
                distanceMoved = 0f; // reset distanceMoved here
            } else {
                // Otherwise, reset the position to the starting position
                previousPosition = transform.position;
                transform.position = startPosition;
            }
        }
    }
}