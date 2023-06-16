using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image loadingBarFill;

    public void LoadingScene(string sceneName){
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);

        while(!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
