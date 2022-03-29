using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankCameraFPS : MonoBehaviour
{
    //Camera
    public bool activeCam = false;


    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;


    void Start()
    {
        initalOffset = transform.position - targetObject.position;
    }

    private void Update()
    {
        if(activeCam != true)
        {
            return;
        }
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = cameraPosition;
    }
}
