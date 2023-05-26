using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string sceneName;
    
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void TombolKeluar()
    {
        Application.Quit();
        Debug.Log("tombol sudah ditekan");
    }

    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}