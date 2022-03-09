using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShooting : MonoBehaviour
{
        //Turn vector
    public Vector2 turn;

    public GameObject obj;

    public float barrelRotX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        

        
        barrelRotX = Mathf.Clamp(barrelRotX, -45f, 20f);
        obj.transform.rotation = Quaternion.Euler(turn.y, obj.transform.rotation.eulerAngles.y, 20);

        
    }
}
