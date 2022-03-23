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
    public float minBarrelRotX = 5; 
    public float maxBarrelRotX = 10;


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




        //Move tank turret & barrrel with mouse
        //Base

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        tankTurretBase.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        //Detect max movements values

        Debug.Log(Quaternion.Euler(0, tankBarrel.transform.rotation.eulerAngles.x, 0));

        if (tankBarrel.transform.rotation.eulerAngles.x > maxBarrelRotX)
        {
            barrelRotX = maxBarrelRotX;
        }

        if (tankBarrel.transform.rotation.eulerAngles.x < minBarrelRotX)
        {
            barrelRotX = minBarrelRotX;
        }


        //Barrel movement
        barrelRotX = Mathf.Clamp(barrelRotX, -45f, 20f);
        tankBarrel.transform.rotation = Quaternion.Euler(turn.y, tankBarrel.transform.rotation.eulerAngles.y, 20);
        
    }
}

