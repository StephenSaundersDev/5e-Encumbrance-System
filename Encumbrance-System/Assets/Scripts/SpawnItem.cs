using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    public GameObject parentObject;
    public Transform cornerOne;
    public Transform cornerTwo;
    public Dropdown itemDropDown;
    private int itemID;

    public List<GameObject> itemPrefabList = new List<GameObject>();

    /*
    0 = Custom Item
    1 = One-Handed Weapon
    2 = Two-Handed Weapon
    3 = Light Armor
    4 = Medium Armor
    5 = Heavy Armor
    6 = Full Quiver
    7 = 1000 Coins
    */


    public void Spawn()
    {
        itemID = itemDropDown.value;
        Vector3 spawnLocation = new Vector3(Random.Range(cornerOne.position.x, cornerTwo.position.x), UnityEngine.Random.Range(cornerOne.position.y, cornerTwo.position.y), 0);


        GameObject childObject = Instantiate(itemPrefabList[itemID], spawnLocation, Quaternion.identity) as GameObject;
        childObject.transform.parent = parentObject.transform;
        Debug.Log("Item Spawned at: " + spawnLocation);
    }
}
