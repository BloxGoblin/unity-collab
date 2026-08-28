using UnityEngine;

public class Build : MonoBehaviour
{
    public static Build Instance;
    public Transform player;
    public Transform preBuildParent;

    public void SelectBuild(Constructible constructible)
    {
        Player.Instance.buildSelected = constructible;
    }

    void Update()
    {
        if (Player.Instance.buildSelected != null)
        {
            
        }
    }
}
