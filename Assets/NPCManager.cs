using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private DialogData data;
    [SerializeField] private bool hasDialog;
    [SerializeField] private bool hasQuiz;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            UIManager.Instance.ShowDialogButton(hasDialog);
            UIManager.Instance.ShowQuizButton(hasQuiz);
            UIManager.Instance.DialogData = data;
        }
    }
}
