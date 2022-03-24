using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletExplod : MonoBehaviour
{

    //The bullet is destroy when he enter in an other collision
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        //Add explod animation
    }

}
