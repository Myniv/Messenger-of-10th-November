using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC2 : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject panelChapter;
    public string[] dialogue;
    private int index;
    [SerializeField] GameObject button;

    [SerializeField] GameObject contButton;
    [SerializeField] GameObject quiz;
    [SerializeField] float wordSpeed;
    [SerializeField] bool playerIsClose;
    AudioManager audioManager;
    [SerializeField] UnityEvent finishDialog;

    bool dialogOn=false;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            audioManager.PlaySFX(audioManager.Typing);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }

        else
        {
            quiz.SetActive(false);
            Debug.Log("test");
            zeroText();
            finishDialog.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")||dialogOn==false)
        {
            playerIsClose = true;
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            dialoguePanel.SetActive(false);
            button.SetActive(false);
            zeroText();
            dialogOn=true;
        }
    }
}
