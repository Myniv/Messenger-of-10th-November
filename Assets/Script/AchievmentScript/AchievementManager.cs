using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] GameObject achievmentPrefab;

    [SerializeField] Sprite[] sprites;

    [SerializeField] ScrollRect scrollRect;
    private AchievementButton activeButton;


    void Start()
    {
        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();
        CreateAchievment("General", "TestTitle", "This is Description", 0);
        CreateAchievment("General", "TestTitle", "This is Description", 0);
        CreateAchievment("General", "TestTitle", "This is Description", 0);
        CreateAchievment("General", "TestTitle", "This is Description", 0);
        CreateAchievment("General", "TestTitle", "This is Description", 0);
        CreateAchievment("General", "TestTitle", "This is Description", 0);

        CreateAchievment("Other", "TestTitleOther", "This is Description", 0);
        CreateAchievment("Other", "TestTitleOther", "This is Description", 0);
        CreateAchievment("Other", "TestTitleOther", "This is Description", 0);
        CreateAchievment("Other", "TestTitleOther", "This is Description", 0);
        CreateAchievment("Other", "TestTitleOther", "This is Description", 0);
        CreateAchievment("Other", "TestTitleOther", "This is Description", 0);

        foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click();
    }


    public void CreateAchievment(string category, string title, string description, int spriteIndex)
    {
        GameObject achievment = (GameObject)Instantiate(achievmentPrefab);
        SetAchievmnetInfo(category, achievment, title, description, spriteIndex);
    }

    public void SetAchievmnetInfo(string category, GameObject achievment, string title, string description, int spriteIndex)
    {
        achievment.transform.SetParent(GameObject.Find(category).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<TMP_Text>().text = title; //Title
        achievment.transform.GetChild(1).GetComponent<TMP_Text>().text = description; //description
        achievment.transform.GetChild(2).GetComponent<Image>().sprite = sprites[spriteIndex]; //sprite
    }

    public void ChangeCategory(AchievementButton button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();
        scrollRect.content = achievementButton.achievmentList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;
    }
}
