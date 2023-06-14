using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int minigamescount;
    [SerializeField] int miniGameFinish;
    [SerializeField] GameObject panelNextScene;
    public void AddMiniGamesFinish () 
    {
        minigamescount++;
    }
    public void IsMiniGamesFinish () 
    {
        if(minigamescount==miniGameFinish){
            panelNextScene.SetActive(true);
        }
    }
}