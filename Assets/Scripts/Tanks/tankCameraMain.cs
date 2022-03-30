using UnityEngine;

public class tankCameraMain : MonoBehaviour
{
    //Camera
    public Transform tankTransform;
    private float _rotationX;
    private float _rotationY;

    [SerializeField]
    public float rotationSpeed = 3.0f;
    [SerializeField]
    private float _smoothTime = 0.3f;
    [SerializeField]
    private float _distanceFromTarget = 10.0f;

    public Quaternion camTurnAngle;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    private void Start()
    {
        transform.position = tankTransform.position - transform.forward * _distanceFromTarget;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            _rotationX += mouseY;
            _rotationY += mouseX;

            _rotationX = Mathf.Clamp(_rotationX, -5, 40);

            Vector3 netxtRotation = new Vector3(_rotationX, _rotationY);
            _currentRotation = Vector3.SmoothDamp(_currentRotation, netxtRotation, ref _smoothVelocity, _smoothTime);
            transform.localEulerAngles = _currentRotation;

            transform.position = tankTransform.position - transform.forward * _distanceFromTarget;

        }
    }


}
