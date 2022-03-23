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
            var bullet = Instantiate(ammo, barrelEnd.position, barrelEnd.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = (barrelEnd.transform.up).normalized * bulletSpeed;
       
            Destroy(bullet, despawnTime);

            ammoCount--;
            Debug.Log(ammoCount + " / " + maxAmmo);
        }

        //Animation telling we don't have any ammo
        else
        {
            Debug.Log("Le chargeur est vide");
        }

    }

}