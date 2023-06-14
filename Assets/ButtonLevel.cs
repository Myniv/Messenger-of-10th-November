using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] List<Button> buttonList;


    private void Start(){
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].interactable=false;
        }

        var levelDone = PlayerPrefs.GetInt("LevelDone");
        for (int i = 0; i < buttonList.Count; i++)
        {
            if(levelDone >= i){
                buttonList[i].interactable=true;
            }
        }
    } 
}
