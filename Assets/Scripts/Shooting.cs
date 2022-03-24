using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject ammo;
    public Transform barrelEnd;

    public int bulletSpeed = 100;
    public float despawnTime = 3.0f;

    public bool shootAble = true;
    public float waitBeforeNextShot = 0.25f;

    public int maxAmmo = 7;
    private int ammoCount;

    public GameObject barrelExplosionAnimation;

    private void Start()
    {
        //Define the current ammo amount
        ammoCount = maxAmmo;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootAble)
            {
                shootAble = false;
                Shoot();
                StartCoroutine(ShootingYield());
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            ammoCount = maxAmmo;
            Debug.Log("Rechargement du tank");
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }

    void Shoot()
    {

        if (ammoCount > 0)
        {
            ammoCount--;

            //Barrel shoot explosion animation
            var barrelExplosion = Instantiate(barrelExplosionAnimation, barrelEnd.position, barrelEnd.rotation);
            Destroy(barrelExplosion, despawnTime);


            var bulletShoot = Instantiate(ammo, barrelEnd.position, barrelEnd.rotation) as GameObject;
            bulletShoot.GetComponent<Rigidbody>().velocity = (barrelEnd.transform.up).normalized * bulletSpeed;

            
            Debug.Log(ammoCount + " / " + maxAmmo);

            //On ajoute la classe dans la bullet
            var script = bulletShoot.AddComponent<bulletExplod>() as bulletExplod;

            Destroy(bulletShoot, despawnTime);
        }

        //Animation telling we don't have any ammo
        else
        {
            Debug.Log("Le chargeur est vide");
        }



    }

}