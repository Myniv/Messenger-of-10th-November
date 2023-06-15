using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCQuiz : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    [SerializeField] GameObject button;

    [SerializeField] GameObject contButton;
    [SerializeField] GameObject quiz;
    [SerializeField] float wordSpeed;
    [SerializeField] bool playerIsClose;
    AudioManager audioManager;

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
        dialogueText.text = dialogue[index];
        index = 0;
        dialoguePanel.SetActive(false);
        contButton.SetActive(true);
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
            quiz.SetActive(true);
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")||dialogOn==false)
        {
            playerIsClose = true;
            // dialoguePanel.SetActive(true);
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            button.SetActive(false);
            dialoguePanel.SetActive(value: false);
            zeroText();
            dialogOn=true;
        }
    }
}
