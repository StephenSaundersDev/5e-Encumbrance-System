using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItemInput : MonoBehaviour
{
    public bool toggleFlag = true;

    public void Toggle()
    {
        if (toggleFlag == false)
        {
            toggleFlag = true;
            gameObject.SetActive(false);
        }
        else if (toggleFlag == true)
        {
            toggleFlag = false;
            gameObject.SetActive(true);
        }
    }
}
