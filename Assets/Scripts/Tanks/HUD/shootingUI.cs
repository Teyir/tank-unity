using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootingUI : MonoBehaviour
{

    public Text ammoDisplay;
    private int ammoCount = 0;
    private int maxAmmo;

    public void updateAmmo(int ammo, int ammoMax)
    {
        ammoCount = ammo;
        maxAmmo = ammoMax;
        ammoDisplay.text = ammoCount.ToString() + " / " + maxAmmo.ToString();
    }

    public void updateCanShoot(bool status)
    {
        if(status == true)
        {
            ammoDisplay.color = Color.green;
        }
        else if (status == false)
        {
            ammoDisplay.color = Color.red;
        }
    }
}
