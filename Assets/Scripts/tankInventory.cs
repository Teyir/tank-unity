using System.Collections.Generic;
using UnityEngine;

public class tankInventory : MonoBehaviour
{

    public Inventory inventory = new Inventory();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            saveToJSON();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            loadToJSON();
        }
    }

    public void saveToJSON()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/inventoryData.json";

        System.IO.File.WriteAllText(filePath, inventoryData);
    }

    public void loadToJSON()
    {
        string filePath = Application.persistentDataPath + "/inventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);

        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
    }

}


[System.Serializable]
public class Inventory
{
    public int ammo; //current tank ammo
    public bool isFull; //tank inv is full or not 
    public List<Items> items = new List<Items>();
}

[System.Serializable]
public class Items
{
    public string name;
    public string description;

}