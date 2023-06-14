using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int minigamescount;
    int miniGameFinish;
    public static LevelManager levelManager;
    public void AddMiniGamesFinish () 
    {
        minigamescount++;
    }
    public bool IsMiniGamesFinish () 
    {
        return miniGameFinish >= minigamescount;
    }
}