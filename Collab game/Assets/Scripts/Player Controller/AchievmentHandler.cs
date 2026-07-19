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
                print("Guy unlocked achievment hooray");
                SaveAchievment();
                break;
            }
        }
    }

    private void SaveAchievment()
    {
        PlayerPrefs.DeleteAll();
    }
}