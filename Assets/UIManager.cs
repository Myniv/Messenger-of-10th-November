using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button dialogButton;
    [SerializeField] private Button quizButton;

    public static UIManager Instance;
    
    public DialogData DialogData { get; set; }

    private void Awake()
    {
        Instance = this;
        ShowDialogButton(false);
        ShowQuizButton(false);
    }

    public void ShowDialogButton(bool active)
    {
        dialogButton.gameObject.SetActive(active);
    }

    public void ShowQuizButton(bool active)
    {
        quizButton.gameObject.SetActive(active);
    }

    public void ShowDialog()
    {
        Debug.Log(DialogData.name);
    }
    
}
