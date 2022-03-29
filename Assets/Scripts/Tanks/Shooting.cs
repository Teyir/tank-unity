using System.Collections;
using UnityEngine;
using Mirror;

public class Shooting : NetworkBehaviour
{

    public GameObject ammo;
    public Transform barrelEnd;

    public int bulletSpeed = 100;
    public float despawnTime = 3.0f;

    public bool canShoot = true;
    public float waitBeforeNextShot = 0.25f;

    public int maxAmmo = 7;
    private int ammoCount;

    public GameObject barrelExplosionAnimation;

    private shootingUI shootingHUD;

    private void Awake()
    {
        shootingHUD = GameObject.FindObjectOfType<shootingUI>();
    }

    private void Start()
    {
        //Define the current ammo amount
        ammoCount = maxAmmo;
        shootingHUD.updateAmmo(ammoCount, maxAmmo);
    }

    private void Update()
    {

        if(!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canShoot)
            {
                canShoot = false;
                Shoot();
                StartCoroutine(ShootingYield());

                shootingHUD.updateCanShoot(canShoot);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            reload();
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        canShoot = true;
        shootingHUD.updateCanShoot(canShoot);
    }

    [Command]
    void Shoot()
    {
        
        if (ammoCount > 0)
        {
            
            ammoCount--;
            shootingHUD.updateAmmo(ammoCount, maxAmmo);

            //Barrel shoot explosion animation
            barrelExplosionAnimation.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //animation scale (-50%)
            var barrelExplosion = Instantiate(barrelExplosionAnimation, barrelEnd.position, barrelEnd.rotation);
            NetworkServer.Spawn(barrelExplosion);
            Destroy(barrelExplosion, despawnTime);


            var bulletShoot = Instantiate(ammo, barrelEnd.position, barrelEnd.rotation) as GameObject;
            bulletShoot.GetComponent<Rigidbody>().velocity = (barrelEnd.transform.up).normalized * bulletSpeed;

            NetworkServer.Spawn(bulletShoot);

            Debug.Log(ammoCount + " / " + maxAmmo);

            //On ajoute la classe dans la bullet
            //var script = bulletShoot.AddComponent<bulletExplod>() as bulletExplod;

            Destroy(bulletShoot, despawnTime);
        }

        //Animation telling we don't have any ammo
        else
        {
            Debug.Log("Le chargeur est vide");
        }

    }
        

    [Command]
    void reload()
    {
        ammoCount = maxAmmo;
        shootingHUD.updateAmmo(ammoCount, maxAmmo);
        Debug.Log("Rechargement du tank");
    }
   

}