using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextLevelButton : MonoBehaviour
{
    [SerializeField] int currentLevel;

    public void UnlockNextLevel(){
        PlayerPrefs.SetInt("LevelDone", currentLevel);
    }
}
