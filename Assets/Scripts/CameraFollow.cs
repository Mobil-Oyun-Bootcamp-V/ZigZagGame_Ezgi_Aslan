using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform SphereLocation;
    Vector3 Distance;
    void Start()
    {
        Distance = transform.position - SphereLocation.position;
    }

    void Update()
    {
        if (PlayerMovement.fall == false)
        {
            transform.position = SphereLocation.position + Distance;
        }
        
    }
}
