using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectVisibilityController : MonoBehaviour
{
    public float distanceThreshold = 0.5f;
    public GameObject sphereObject;
    public GameObject textObject;

    private bool itemPlacedOnTable = false;

    private Renderer sphereRenderer;
    private Collider sphereCollider;
    private Renderer cubeRenderer;
    private Collider cubeCollider;
    

    private void Start()
    {
        Debug.Log("sphereObject: " + sphereObject);
        Debug.Log("textObject: " + textObject);

        sphereRenderer = sphereObject.GetComponent<Renderer>();
        sphereCollider = sphereObject.GetComponent<Collider>();
        cubeRenderer = textObject.GetComponent<Renderer>();
        cubeCollider = textObject.GetComponent<Collider>();

        sphereRenderer.enabled = false;
        sphereCollider.enabled = false;
        cubeCollider.enabled = false;
        cubeCollider.enabled = false;
        cubeRenderer.gameObject.SetActive(false);
    }

    private void Update()
    {
        GameObject[] itemsWithTag = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject item in itemsWithTag)
        {
            if (Vector3.Distance(transform.position, item.transform.position) < distanceThreshold)
            {
                itemPlacedOnTable = true;
                break;
            }
        }

        if (itemPlacedOnTable)
        {
            sphereRenderer.enabled = true;
            sphereCollider.enabled = true;
            cubeCollider.enabled = true;
            cubeCollider.enabled = true;
            cubeRenderer.gameObject.SetActive(true);
        }
    }
}