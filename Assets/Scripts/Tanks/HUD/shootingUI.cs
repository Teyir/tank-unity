using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootingUI : MonoBehaviour
{

    public Text ammoDisplay;
    public int ammoCount;

    public shootingUI(int ammountAmmo)
    {
        ammoCount = ammountAmmo;
    }

    void Update()
    {
        ammoDisplay.text = ammoCount.ToString();
        
    }
}
