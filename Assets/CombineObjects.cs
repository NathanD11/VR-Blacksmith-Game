using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObjects : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject resultObject;
    
    void Update()
    {
        // Check if both objectA and objectB are present
        if (objectA != null && objectB != null)
        {
            // Instantiate the resultObject at the position of the invisible game object
            Instantiate(resultObject, transform.position, transform.rotation);
            
            // Destroy objectA and objectB
            Destroy(objectA);
            Destroy(objectB);
            
            // Destroy the invisible game object if you don't need it anymore
            Destroy(gameObject);
        }
    }
}
