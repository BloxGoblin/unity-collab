using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public GameObject player;
    public bool playing = false;

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject achievementMenu;
    public GameObject optionsMenu;

    void Start()
    {
        mainMenu.SetActive(true);

        // load achievements as soon as game starts

        AchievementData data = SaveSystem.LoadAchievements(this);

        if (data != null)
        {
            foreach (var id in data.achievements)
            {
                foreach (var achievement in player.GetComponent<AchievmentHandler>().achievments.achievments)
                {
                    if (achievement.id == id)
                    {
                        player.GetComponent<AchievmentHandler>().UnlockedAchievements.Add(achievement);
                        continue;
                    }
                }
            }
        }
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayerData(this);

        SaveSystem.SaveAchievments(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayerData(this);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        // inventory
        foreach (var id in data.inventory)
        {
            foreach (var item in ItemsIndex.Instance.ItemIndex)
            {
                if (item.id == id)
                {
                    InventoryManager.Instance.Add(item);
                    continue;
                }
            }
        }
    }

    public void SaveAchievements()
    {
        SaveSystem.SaveAchievments(this);
    }

    void Update()
    {
        //Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (player.GetComponent<Player>().playing == true)
            {
                pauseMenu.SetActive(true);
                CameraController.Instance.UnlockMouse();
                player.GetComponent<Player>().playing = false;
            }
            else if (achievementMenu.activeSelf == true)
            {
                achievementMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
            else if (optionsMenu.activeSelf == true)
            {
                OptionsMenu.Instance.CloseOptionsUI();
            }
        }
    }
}
