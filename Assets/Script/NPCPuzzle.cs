using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCPuzzle : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject button;
    [SerializeField] TMP_Text dialogueText;
    private string chaceDialogueText;
    // [SerializeField] Image dialogueImage;
    [SerializeField] string[] dialogue;
    [SerializeField] string[] dialogueWinPuzzle;
    // [SerializeField] Sprite KarakterImage;
    // [SerializeField] TMP_Text dialogueName;
    // [SerializeField] string KaraterName;
    private int index;

    [SerializeField] GameObject contButton;
    // [SerializeField] GameObject quiz;
    [SerializeField] float wordSpeed;
    [SerializeField] bool playerIsClose;
    [SerializeField] UnityEvent notifAchievement;
    AudioManager audioManager;

    bool dialogOff = false;

    [SerializeField] hiddenManager hiddenManager;



    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        chaceDialogueText=dialogueText.text;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                // dialogueImage.sprite = KarakterImage;
                StartCoroutine(Typing());
            }
        }
        if (hiddenManager.IsPuzzleWin == false)
        {
            if (dialogueText.text == dialogue[index]||dialogueText.text==chaceDialogueText)
            {
                contButton.SetActive(true);
            }
        }
        else if (hiddenManager.IsPuzzleWin == true)
        {
            if (dialogueText.text == dialogueWinPuzzle[index]||dialogueText.text==chaceDialogueText)
            {
                contButton.SetActive(true);
            }
        }
        
    }

    public void zeroText()
    {
        dialogueText.text = chaceDialogueText;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        if (hiddenManager.IsPuzzleWin == false)
        {

            foreach (char letter in dialogue[index].ToCharArray())
            {

                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                audioManager.PlaySFX(audioManager.Typing);
            }
        }
        else if (hiddenManager.IsPuzzleWin == true)
        {
            foreach (char letter in dialogueWinPuzzle[index].ToCharArray())
            {

                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                audioManager.PlaySFX(audioManager.Typing);
            }

        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);
        if (hiddenManager.IsPuzzleWin == false)
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }

            else
            {
                puzzle.SetActive(true);
                Debug.Log("test");
                zeroText();
            }
        }
        else if (hiddenManager.IsPuzzleWin == true)
        {
            if (index < dialogueWinPuzzle.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
                notifAchievement.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || dialogOff == false)
        {
            //To Activate notif in the npc
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            playerIsClose = true;
            button.SetActive(true);
            // dialogueImage.sprite = KarakterImage;
            // dialogueName.text = KaraterName;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //To Deactivate notif in the npc
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            button.SetActive(false);
            playerIsClose = false;
            notifAchievement.Invoke();
            dialoguePanel.SetActive(value: false);
            zeroText();
            dialogOff = true;
        }
    }
}
