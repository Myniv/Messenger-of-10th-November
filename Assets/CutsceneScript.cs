using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] int detikVideo = 60;
    void Start()
    {
        StartCoroutine(waitVideo(detikVideo));
    }

    // Update is called once per frame
    private IEnumerator waitVideo(int second)
    {
        yield return new WaitForSecondsRealtime(second);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }
}
