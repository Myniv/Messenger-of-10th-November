using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class hiddenManager : MonoBehaviour
{
    public GameObject item;
    public GameObject[] itemTarget;
    public int[] randomIndexs;
    public GameObject panelFinish;
    int countItemFind;
    public int countHealth;
    public GameObject health;
    public TMP_Text textGagal;
    AudioManager audioManager;
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start() 
    {
        RandomItemPos();

        RandomIndex();

        RandomItemTarget();
    }
    void RandomIndex()
    {
        for(int i = 0; i < randomIndexs.Length; i++) 
        {
            int a = randomIndexs[i];
            // int b = Random.Range(0, randomIndexs.Length);
            // randomIndexs[i] = randomIndexs[b];
            // randomIndexs[b] = a;
        }
    }
    void RandomItemTarget()
    {
        for(int i = 0; i < itemTarget.Length; i++) 
        {
            itemTarget[i].GetComponent<Image>().sprite = item.transform.GetChild(randomIndexs[i]).GetComponent<Image>().sprite;
        }
    }
    public void RandomItemPos() 
    {
        int randomSave = Random.Range(0,ControlPos.Instance.saveItemsPos.Count);

        for(int i = 0; i < item.transform.childCount; i++) 
        {
            item.transform.GetChild(i).transform.localPosition = ControlPos.Instance.saveItemsPos[randomSave].itemPos[i];

            item.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void ButtonItem() 
    {
        for(int i = 0; i < itemTarget.Length; i++) 
        {    
            if(EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite == itemTarget[i].GetComponent<Image>().sprite)
            {
                itemTarget[i].GetComponent<Image>().color = Color.white;

                countItemFind++;
                Debug.Log("benar " + countItemFind);
                audioManager.PlaySFX(audioManager.CorrectAnswer);
                if (countItemFind >= itemTarget.Length)
                {
                    panelFinish.SetActive(true);
                }

                EventSystem.current.currentSelectedGameObject.gameObject.SetActive(false);
                
                return;
            }
            else
            {
                if(i == itemTarget.Length - 1)
                {
                    Debug.Log("salah");
                    if(countHealth > 0) {

                        health.transform.GetChild(countHealth - 1).gameObject.SetActive(false);
                        countHealth -= 1;
                        audioManager.PlaySFX(audioManager.WrongAnswer);
                    }
                    else
                    {
                        panelFinish.SetActive(true);
                        textGagal.text = "Misi Gagal";
                    }
                }
            }
            
        }
    }

    public void Ulangi () 
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        countHealth=3;

        for(int i = 0; i < itemTarget.Length; i++) 
        {
                itemTarget[i].GetComponent<Image>().color = Color.black;
        }

        RandomItemPos();

        // RandomIndex();

        // RandomItemTarget();
    }
}
