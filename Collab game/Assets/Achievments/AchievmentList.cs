using UnityEngine;

[CreateAssetMenu(fileName = "AchievmentList", menuName = "AchievmentList/Achievment List")]

public class AchievmentList : ScriptableObject
{
    public Achievment[] achievments;
}

[System.Serializable]
public class Achievment
{
    public int id;
    public string achievmentName;
    public string achievmentDesc;
    public Sprite icon;
    public float requiredAmount;
    public float progression;
}