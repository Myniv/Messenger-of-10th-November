using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    private int totalSkillPoint;

    public void Answer(){
        if(isCorrect){
            Debug.Log("Correct Answer");
            quizManager.QnA.RemoveAt(quizManager.currentQuestion);
            quizManager.ValueSkillPoint+=10;
            quizManager.correct();
            
        }else {
            Debug.Log("Wrong Answer");
            quizManager.QnA.RemoveAt(quizManager.currentQuestion);
            quizManager.correct();
        }
    }
}
