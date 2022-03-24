using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletExplod : MonoBehaviour
{

    //The bullet is destroy when he enter in an other collision
    public void OnCollisionEnter(Collision collision)
    {
        var collisionExplosionAnimation = GameObject.Find("collisionExplosion_Heavy");


        //Explod animation
        var explosion = Instantiate(collisionExplosionAnimation, transform.position, transform.rotation) as GameObject;

        Destroy(this.gameObject);
        Destroy(explosion, 5f);
        return;
    }

}
