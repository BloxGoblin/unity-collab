using UnityEngine;

public class AchievmentHandler : MonoBehaviour
{
    public static AchievmentHandler Instance;

    [SerializeField]
    private AchievmentList achievments;

    private void Awake()
    {
        Instance = this;
    }
    public void award(int id)
    {
        foreach(var achievment in achievments.achievments)
        {
            if (achievment.id == id)
            {
                if (PlayerPrefs.GetInt(achievment.achievmentName, 0) == 1) // Guy already has the achievment
                {
                    break;
                }

                print("Guy unlocked achievment hooray");
                SaveAchievment(achievment.achievmentName);
                break;
            }
        }
    }

    private void SaveAchievment(string achievmentName)
    {
        PlayerPrefs.SetInt(achievmentName, 1);
    }
}