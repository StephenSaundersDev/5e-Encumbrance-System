using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVolume : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();

    public GameObject volumePrefab;

    public int customVolumeCount = 0;

    public void Spawn()
    {
        Debug.Log(customVolumeCount);
        if (customVolumeCount < 3)
        {
            GameObject childObject = Instantiate(volumePrefab, points[customVolumeCount].position, Quaternion.identity) as GameObject;
            childObject.transform.parent = points[customVolumeCount].transform;
            Debug.Log("Item Spawned at: " + points[customVolumeCount].position);
            if(customVolumeCount == 2)
            {
                gameObject.SetActive(false);
            }
            customVolumeCount++;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
