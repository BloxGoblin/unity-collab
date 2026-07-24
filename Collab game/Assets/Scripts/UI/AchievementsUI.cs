using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AchievementsUI : MonoBehaviour
{
    public static AchievementsUI Instance;
    public GameObject achievementsUI;
    public Transform UiContainer;
    public GameObject template;
    public Transform player;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenAchievementsUI(GameObject currentMenu)
    {
        achievementsUI.SetActive(true);
        ListAchievements();
    }
    public void ListAchievements()
    {
        foreach (var achievement in player.GetComponent<AchievmentHandler>().achievments.achievments)
        {
            GameObject panel = Instantiate(template, UiContainer);

            panel.transform.Find("Name").GetComponent<TMP_Text>().text = achievement.achievmentName;
            panel.transform.Find("Description").GetComponent<TMP_Text>().text = achievement.achievmentDesc;
            if (achievement.icon)
            {
                panel.transform.Find("Icon").GetComponent<Image>().sprite = achievement.icon;
            }
            foreach (var unlocked in player.GetComponent<AchievmentHandler>().UnlockedAchievements)
            {
                if (achievement.id == unlocked.id) //Guy has the achievement
                {
                    panel.GetComponent<Graphic>().color = Color.green;
                }
            }
        }
    }
}
