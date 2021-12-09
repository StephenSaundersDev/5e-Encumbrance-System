using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemInfo : MonoBehaviour
{
    public float itemBulk = 0;
    public string itemName = "Unnamed Item";

    public GameObject itemBulkInput;
    public GameObject itemNameInput;

    public void Update()
    {
        SetItemValues();
    }
    public void SetItemValues()
    {
        if (itemBulkInput.GetComponent<Text>().text.Any(char.IsDigit))
        {
            Debug.Log("Text contains a number");
            itemBulk = float.Parse(itemBulkInput.GetComponent<Text>().text);
            itemName = itemNameInput.GetComponent<Text>().text;
        }
    }

}
