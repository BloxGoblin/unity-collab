using System.Security;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public float[] achievements;
    public AchievementData (Player player)
    {
        achievements = GetAchievements(player);
    }

    float[] GetAchievements(Player player)
    {
        int index = 0;
        int achievementsNum = player.GetComponent<AchievmentHandler>().UnlockedAchievements.Count;

        float[] Achievements = new float[achievementsNum];

        foreach (var achievement in player.GetComponent<AchievmentHandler>().UnlockedAchievements)
        {
            Achievements[index] = achievement.id;
            index += 1;
        }

        return Achievements;
    }
}
