using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] QuizManager quizManager;

    private void Start() {
        var gameOver=quizManager.GameOver1;
        if(gameOver==true){
            this.gameObject.SetActive(false);
        }
    }

    
}
