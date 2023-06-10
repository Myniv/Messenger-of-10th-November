using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    [SerializeField] GameObject truePopUp;
    [SerializeField] GameObject falsePopUp;
    AudioManager audioManager;
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Answer(){
        if(isCorrect){
            Debug.Log("Correct Answer");
            quizManager.correctAnswer++;
            StartCoroutine(PopUpTrueOrAnswer());
            quizManager.correct();
            audioManager.PlaySFX(audioManager.CorrectAnswer);
        }else {
            Debug.Log("Wrong Answer");
            StartCoroutine(PopUpTrueOrAnswer());
            quizManager.correct();
            audioManager.PlaySFX(audioManager.WrongAnswer);
        }
    }

    private IEnumerator PopUpTrueOrAnswer(){
        if(isCorrect){
            truePopUp.SetActive(true);
            yield return new WaitForSecondsRealtime(time: 0.8f);
            truePopUp.SetActive(false);
        }else{
            falsePopUp.SetActive(true);
            yield return new WaitForSecondsRealtime(0.8f);
            falsePopUp.SetActive(false);
        }
    }
}
