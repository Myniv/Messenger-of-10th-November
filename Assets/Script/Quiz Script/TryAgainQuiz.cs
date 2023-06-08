using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainQuiz : MonoBehaviour
{
    [SerializeField] QuizManager quizManager;

    private void Start() {
        var winGame=quizManager.WinGame;
        if(winGame==true){
            this.gameObject.SetActive(false);
        } else{
            this.gameObject.SetActive(true);
        }
    }

    
}
