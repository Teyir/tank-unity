using UnityEngine;

public class bulletExplod : MonoBehaviour
{
    public GameObject collisionExplosion;

    //The bullet is destroy when he enter in an other collision 
    public void OnCollisionEnter(Collision collision)
    {
        //Explod animation
        var explosion = Instantiate(collisionExplosion, transform.position, transform.rotation) as GameObject;

        Destroy(this.gameObject);
        Destroy(explosion, 5f);
        return;
    }
}
