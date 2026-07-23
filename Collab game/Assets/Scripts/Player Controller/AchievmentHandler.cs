using System.Runtime.CompilerServices;
using UnityEngine;

public class AchievmentHandler : MonoBehaviour
{
    public static AchievmentHandler Instance;

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
                print("Guy unlocked achievment hooray");
                SaveAchievment(id);
                break;
            }
        }
    }

    private void SaveAchievment(int id)
    {
        
    }
}