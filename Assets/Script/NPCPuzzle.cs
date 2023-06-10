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
    [SerializeField] TMP_Text dialogueText;
    // [SerializeField] Image dialogueImage;
    [SerializeField] string[] dialogue;
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

    bool dialogOff=false;

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
                // dialogueImage.sprite = KarakterImage;
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
            puzzle.SetActive(true);
            Debug.Log("test");
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")&&dialogOff==false)
        {
            //To Activate notif in the npc
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            playerIsClose = true;
            dialoguePanel.SetActive(true);
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
            
            playerIsClose = false;
            notifAchievement.Invoke();
            dialoguePanel.SetActive(value: false);
            zeroText();
            dialogOff=true;
        }
    }
}
