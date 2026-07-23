using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AchievmentHandler : MonoBehaviour
{
    public static AchievmentHandler Instance;

    public List<Achievment> UnlockedAchievements = new List<Achievment>();

    [SerializeField]
    public AchievmentList achievments;

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
                foreach (var achievement in UnlockedAchievements)
                {
                    if (achievement.id == id)
                    {
                        return; //Guy already has achievement
                    }
                }
                SaveAchievment(id);
                break;
            }
        }
    }

    private void SaveAchievment(int id)
    {
        foreach (var achievement in achievments.achievments)
        {
            if (achievement.id == id)
            {
                UnlockedAchievements.Add(achievement);
                print("Guy unlocked achievment hooray");
            }
        }
    }
}