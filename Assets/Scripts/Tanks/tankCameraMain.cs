using UnityEngine;

public class tankCameraMain : MonoBehaviour
{
    //Camera
    public Transform tankTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    public bool lookPlayer = false;
    public bool rotateAroundPlayer = true;
    public float cameraRotationSpeed = 5.0f;
    public float rotationSpeed = 5f;

    void Start()
    {
        //Camera
        _cameraOffset = transform.position - tankTransform.position;
    }


    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (rotateAroundPlayer)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
                _cameraOffset = camTurnAngle * _cameraOffset;
            }
        }

        Vector3 newPos = tankTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookPlayer || rotateAroundPlayer)
            transform.LookAt(tankTransform);

    }
}
