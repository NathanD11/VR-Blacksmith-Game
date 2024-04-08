using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }

}