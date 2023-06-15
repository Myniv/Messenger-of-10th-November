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
    public string[] dialogueWinQuiz;
    private string cacheDialogueText;
    private int index;
    [SerializeField] GameObject button;

    [SerializeField] GameObject contButton;
    [SerializeField] GameObject quiz;
    [SerializeField] float wordSpeed;
    [SerializeField] bool playerIsClose;
    AudioManager audioManager;

    [SerializeField] QuizManager quizManager;


    bool dialogOn = false;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        cacheDialogueText = dialogueText.text;
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
                StartCoroutine(Typing());
            }
        }
        if (quizManager.IsQuizWin == false)
        {
            if (dialogueText.text == dialogue[index] || dialogueText.text == cacheDialogueText)
            {
                contButton.SetActive(true);
            }
        }
        else if (quizManager.IsQuizWin == true)
        {
            if (dialogueText.text == dialogueWinQuiz[index] || dialogueText.text == cacheDialogueText)
            {
                contButton.SetActive(true);
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = cacheDialogueText;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        if (quizManager.IsQuizWin == false)
        {
            foreach (char letter in dialogue[index].ToCharArray())
            {

                dialogueText.text += letter;
                yield return new WaitForSeconds(wordSpeed);
                audioManager.PlaySFX(audioManager.Typing);
            }
        }
        else if (quizManager.IsQuizWin == true)
        {
            foreach (char letter in dialogueWinQuiz[index].ToCharArray())
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
        if (quizManager.IsQuizWin == false)
        {
            if (index < dialogue.Length - 1)
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
        else if (quizManager.IsQuizWin == true)
        {
            if (index < dialogueWinQuiz.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || dialogOn == false)
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
            dialogOn = true;
        }
    }
}
