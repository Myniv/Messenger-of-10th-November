using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void GamePlay(string sceneName)
    {
        SceneManager.LoadScene("Movement Scene");
    }
    public void LevelList(string sceneName)
    {
        SceneManager.LoadScene("Mulai");
    }
    public void Option(string sceneName)
    {
        SceneManager.LoadScene("Pengaturan");
    }
    public void Menu(string sceneName)
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void TombolKeluar()
    {
        Application.Quit();
        Debug.Log("tombol sudah ditekan");
    }
}