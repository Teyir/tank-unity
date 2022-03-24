using UnityEngine;

public class TankController : MonoBehaviour
{
    //Basiques movements config
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;

    //Turn vector
    public Vector2 turn;

    //Turret + barrel movements
    public GameObject tankTurretBase;
    public GameObject tankBarrel;

    public Quaternion barrelRotation; 
    public float barrelRotX;
    public Quaternion baseRotation;
    public float baseRotY;

    //Max rotations values
    public float minBarrelRotX = -15f; 
    public float maxBarrelRotX = 10f;


    void Start()
    {
        //Remove cursor    
	    Cursor.visible = false;
    }

    void Update()
    {
        //Basique movements
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed);

        //Detect max movements values

        if (turn.y > maxBarrelRotX)
        {
            turn.y = maxBarrelRotX;
        }

        if (turn.y < minBarrelRotX)
        {
            turn.y = minBarrelRotX;
        }


        //Barrel movement

        if (!Input.GetKey(KeyCode.LeftAlt)) //Prevent free camera change barrel position
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            tankTurretBase.transform.localRotation = Quaternion.Euler(0, turn.x, 0);


            barrelRotX = Mathf.Clamp(barrelRotX, -45f, 20f);
            tankBarrel.transform.rotation = Quaternion.Euler(turn.y, tankBarrel.transform.rotation.eulerAngles.y, 20);
        }

    }


}

