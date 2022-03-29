using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootingUI : MonoBehaviour
{

    public Text ammoDisplay;
    private int ammoCount = 0;

    public void updateAmmo(int ammo)
    {
        ammoCount = ammo;
        ammoDisplay.text = ammoCount.ToString();
    }
}
