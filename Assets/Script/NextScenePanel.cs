using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScenePanel : MonoBehaviour
{
    [SerializeField] GameObject nextPanel;
    [SerializeField] TMP_Text confirmText;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            //playerIsClose = true;
            nextPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            //playerIsClose = false;
            nextPanel.SetActive(value: false);
        }
    }

    public void retry()
    {
        nextPanel.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Level 1.2");
    }
}
