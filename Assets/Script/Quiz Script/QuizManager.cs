using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class QuizManager : MonoBehaviour
{
    //Membuat Quiz
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] GameObject falsePopUp;
    [SerializeField] UnityEvent finishQuiz;
    bool winGame = false;
    public bool WinGame { get => winGame; }

    public List<QuestionAndAnaswer> QnA;
    public GameObject[] options;
    public int correctAnswer;
    public TMP_Text QuestiontTxt;
    private bool resetTimerBool = false;
    int currentQuestion = 0;
    [SerializeField] int minCorrect=3;
    private bool isQuizWin=false;

    public bool IsQuizWin { get => isQuizWin;}

    private void Start()
    {
        WaktuMundur = SetWaktu;
        generateQuestion();
    }
    public void correct()
    {
        resetTimer();
        if (resetTimerBool == true)
        {
            WaktuMundur = SetWaktu;
            generateQuestion();

        }
    }
    void SetAnswers()
    {
        resetTimerBool = false;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answer[i];
            resetTimerBool = true;
            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                resetTimerBool = true;
            }
        }

    }
    void generateQuestion()
    {
        if (currentQuestion >= QnA.Count)
        {
            // AfterQuiz();
            StartCoroutine(Wait1Sec());
        }
        else
        {
            QuestiontTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
            currentQuestion++;
        }

    }

    public void GameOver()
    {
        finishedText.text = "Ohh tidak, kamu gagal menyelesaikan quiz ini. Apakah ingin mengulanginya? atau membuka catatan terlebih dahulu?";
        finishedCanvas.SetActive(true);
    }

    public void TryAgain()
    {
        correctAnswer = 0;
        currentQuestion = 0;
        generateQuestion();
        resetTimer();
        Debug.Log("Try Again");
    }

    public void PlayerWin()
    {
        finishedText.text = "Selamat! Kamu telah menyelesaikan quiz ini!";
        finishedCanvas.SetActive(true);
        winGame = true;
        finishQuiz.Invoke();
        isQuizWin=true;
    }

    private void AfterQuiz()
    {
        if (correctAnswer >= minCorrect)
        {
            PlayerWin();
        }
        else
        {
            GameOver();
        }

    }
    private IEnumerator Wait1Sec()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        AfterQuiz();
    }

    //Setting Waktu Mundur
    public TMP_Text TimerText;
    public int SetWaktu = 10;
    private int WaktuMundur;

    void SetText()
    {
        int Detik = WaktuMundur % 60;
        TimerText.text = Detik.ToString("00");
    }
    private IEnumerator PopUpFalseAnswer()
    {
        Debug.Log("TEST");
        falsePopUp.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        falsePopUp.SetActive(false);
    }
    void resetTimer()
    {
        if (WaktuMundur == -1)
        {
            StartCoroutine(PopUpFalseAnswer());
            WaktuMundur = SetWaktu;
            generateQuestion();
        }
    }
    float sec;


    private void Update()
    {
        SetText();
        sec += Time.deltaTime;

        if (sec >= 1)
        {
            WaktuMundur--;
            sec = 0;
        }
    }
    private void LateUpdate()
    {
        resetTimer();
    }
}
