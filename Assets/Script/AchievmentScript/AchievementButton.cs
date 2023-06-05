using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{
    public GameObject achievmentList;

    [SerializeField] Sprite  neutral, highlight;

    private Image sprite;

    [SerializeField] Button noteButton;

    private void Awake() {
        sprite = GetComponent<Image>();
        noteButton.interactable=false;
    }
    
    public void Click(){
        if(sprite.sprite == highlight){
            sprite.sprite = neutral;
            achievmentList.SetActive(false);
        } else{
            sprite.sprite = highlight;
            achievmentList.SetActive(true);
        }
    }
}
