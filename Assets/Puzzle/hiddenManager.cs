using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenManager : MonoBehaviour
{
    public GameObject item;
    private void Start() 
    {
        RandomItemPos();
    }
    public void RandomItemPos() 
    {
        int randomSave = Random.Range(0,ControlPos.Instance.saveItemsPos.Count);

        for(int i = 0; i < item.transform.childCount; i++) 
        {
            item.transform.GetChild(i).transform.localPosition = ControlPos.Instance.saveItemsPos[randomSave].itemPos[i];

            item.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
