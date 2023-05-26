using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPos : MonoBehaviour
{
    public static ControlPos Instance{get; set; }

    [System.Serializable]
    public class ItemList
    {
        public List<Vector2> itemPos;
    }
    public List<ItemList> saveItemsPos; // jumlah save yang diinginkan

    [Header("Item")]
    public GameObject itemParent;
    public int saveNumber;
    private void Awake() {
        Instance = this;
    }

    public void saveItemsPosition () 
    {
        for(int i = 0; i < itemParent.transform.childCount; i++) 
        {
            if(saveItemsPos[saveNumber].itemPos.Count < itemParent.transform.childCount)
            {
                saveItemsPos[saveNumber].itemPos.Add(itemParent.transform.GetChild(i).transform.localPosition);
            }
            else 
            {
                saveItemsPos[saveNumber].itemPos[i] = itemParent.transform.GetChild(i).transform.localPosition;
            }
        }
    }
}
