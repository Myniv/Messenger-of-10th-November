using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    private AchievementButton activeButton;
    public GameObject AchievmentMenu;

    public GameObject visualAchievment;

    int indexAchievementButton;

    public Dictionary<string, Achievment> achievments = new Dictionary<string, Achievment>();
    [SerializeField] List<Button> achievementButtons;
    [SerializeField] Sprite[] sprites;

    public List<AchievmentData> achievmentData;


    void Start()
    {
        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();
        achievementButtons[0].interactable = true;

        foreach (var arch in achievmentData)
        {
            CreateAchievment("other", arch.title, arch.description, arch.spriteIndex);
        }


        foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click();

        AchievmentMenu.SetActive(false);

        CheckPlayerPrefsAchievment();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AchievmentMenu.SetActive(!AchievmentMenu.activeSelf);
            CheckPlayerPrefsAchievment();

        }
    }

    //Perlu
    public void EarnAchievment(string title)
    {
        if (achievments[title].EarnAchievment())
        {
            GameObject achievment = (GameObject)Instantiate(visualAchievment);
            SetAchievmnetInfo("EarnCanvas", achievment, title);

            StartCoroutine(HideAchievment(achievment));

            CheckPlayerPrefsAchievment();
        }
    }

    //Perlu
    public IEnumerator HideAchievment(GameObject achievment)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievment);
    }


    public void CreateAchievment(string parent, string title, string description, int spriteIndex)
    {
        GameObject achievment = (GameObject)Instantiate(visualAchievment);

        Achievment newAchievment = new Achievment(name, description, spriteIndex);

        achievments.Add(title, newAchievment);

    }

    //Untuk membuat notifikasi achievment
    public void SetAchievmnetInfo(string parent, GameObject achievment, string title)
    // , string description, int points, int spriteIndex
    {
        achievment.transform.SetParent(GameObject.Find(parent).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<TMP_Text>().text = title; //Title
        achievment.transform.GetChild(1).GetComponent<TMP_Text>().text = achievments[title].Description; //description
        achievment.transform.GetChild(2).GetComponent<Image>().sprite = sprites[achievments[title].SpriteIndex]; //sprite
    }


    //Untuk menggani category didalam canvas
    public void ChangeCategory(AchievementButton button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();
        scrollRect.content = achievementButton.achievmentList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;
    }

    public void EnabledButtonAchievment(int index)
    {
        PlayerPrefs.SetInt($"Achievment{index}", 1);

    }

    private void CheckPlayerPrefsAchievment()
    {
        for (int i = 1; i < achievementButtons.Count; i++)
        {
            var unlock = PlayerPrefs.GetInt($"Achievment{i}");
            if (unlock == 1)
            {
                achievementButtons[i].interactable = true;
            }
        }
    }
}
