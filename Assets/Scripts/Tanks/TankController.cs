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

    //Camera
    public Camera camTPS;
    public Camera camFPS;

    public int fov = 60;

    //For prevent spam
    public float time = 0.35f;
    public float timer = Time.time;

    //Fuel
    private float fuelCurrent;
    [SerializeField]
    private float fuelMax = 800f;
    public float fuelBurnRate = 75f;

    void Start()
    {
        //Default camera
        camTPS.enabled = true;
        camFPS.enabled = false;

        //Remove cursor    
	    Cursor.visible = false;

        //Fuel setup
        fuelCurrent = fuelMax; //In futur save the data and load them

    }

    void Update()
    {

        //Fuel system
        if (isMoving())
        {
            Debug.Log("Essence: " + fuelCurrent + " / " + fuelMax);
            fuelCurrent -= fuelBurnRate * Time.deltaTime;
        }


        //Stop engine


        //Refuel tank
        if (Input.GetKey(KeyCode.F))
        {
            refuel();
        }


        //Basique movements
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        if (fuelCurrent > 0f)
        {
            transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * movementSpeed);
        }
        

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
            tankBarrel.transform.rotation = Quaternion.Euler(turn.y, tankBarrel.transform.rotation.eulerAngles.y, 0);
        }

        //Camera
        timer += Time.deltaTime;
        if (timer >= time)
        {
            if (Input.GetKey(KeyCode.C))
            {
                camTPS.enabled = !camTPS.enabled;
                camFPS.enabled = !camFPS.enabled;

                timer = 0; //reset the timer
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(camFPS.enabled)
            {
                camFPS.fieldOfView = 30;
            }

            if (camTPS.enabled)
            {
                camTPS.fieldOfView = 30;
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            //Reset fov
            camFPS.fieldOfView = fov;
            camTPS.fieldOfView = fov;

        }



    }

    //Check if the tank is moving
    private bool isMoving()
    {
        if(this.GetComponent<Rigidbody>().velocity.magnitude != 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void refuel()
    {
        fuelCurrent = fuelMax;
        Debug.Log("Rechargement en essence effectué");
    }


}

