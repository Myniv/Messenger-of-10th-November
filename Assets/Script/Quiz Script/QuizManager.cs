using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    //Membuat Quiz
    public List<QuestionAndAnaswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int ValueSkillPoint;
    public TMP_Text QuestiontTxt;
    private bool correct_TF = false;

    private void Start()
    {
        WaktuMundur = SetWaktu;
        generateQuestion();
    }
    public void correct()
    {
        resetTimer();
        if (correct_TF == true)
        {
            WaktuMundur = SetWaktu;
            generateQuestion();
        }
    }
    void SetAnswers()
    {
        correct_TF = false;
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answer[i];
            correct_TF = true;
            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                correct_TF = true;
            }
        }

    }
    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        QuestiontTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
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
    void resetTimer()
    {
        if (WaktuMundur == -1)
        {
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
