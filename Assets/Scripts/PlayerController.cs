using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float mouseSensivityX = 50;
    [SerializeField]
    private float mouseSensivityY = 50;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Player velocity calculs
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);


        //Player rotation calculs (w/ Vector3)
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensivityX;

        motor.Rotate(rotation);

        //Camera rotation calculs (w/ Vector3)
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0 , 0) * mouseSensivityY;

        motor.RotateCamera(cameraRotation);

        


    }
}
