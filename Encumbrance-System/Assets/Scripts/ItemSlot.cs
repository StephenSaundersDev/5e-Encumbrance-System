using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public float bulkValue = 0;
    public Text bulkText;
    public Text strengthText;

    public GameObject item;

    public List<string> items = new List<string>();

    public GameObject dropDownObject;
    public Dropdown itemList;
    public int itemCount = 0;

    public Color customGreen;
    public Color customOrange;
    public Color customRed;

    public float strengthScore = 0;

    public bool PlayerInvFlag = true;

    public void Update()
    {
        if (PlayerInvFlag)
            SetStrengthScore(strengthText.text);

        bulkText.text = "" + bulkValue;

        if (PlayerInvFlag)
        {
            CheckEncumbrance();

            if (items.Count > 0)
            {
                dropDownObject.SetActive(true);
            }
            else
            {
                dropDownObject.SetActive(false);
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            item = eventData.pointerDrag.gameObject;
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            float tempValue = item.GetComponent<ItemInfo>().itemBulk;
            tempValue = (Mathf.Round(tempValue * 10f)) / 10f;
            Debug.Log("Item: " + tempValue);
            bulkValue = bulkValue + tempValue;

            if (PlayerInvFlag)
            {
                items.Add(item.GetComponent<ItemInfo>().itemName);
                itemCount++;
                itemList.ClearOptions();
                itemList.AddOptions(items);
            }

            Destroy(item);
        }
    }

    public void CheckEncumbrance()
    {
        if (bulkValue == 0)
        {
            bulkText.color = Color.white;
        }
        else if(bulkValue <= (strengthScore / 2))
        {
            bulkText.color = customGreen;
        }
        else if (bulkValue <= strengthScore)
        {
            bulkText.color = customOrange;
        }
        else if (bulkValue > strengthScore)
        {
            bulkText.color = customRed;
        }
        else
            bulkText.color = Color.white;
    }

    public void SetStrengthScore(string input)
    {
        if(input != "")
            strengthScore = float.Parse(input);
    }
}
