using Unity.VisualScripting;
using UnityEngine;

public class Build : MonoBehaviour
{
    public static Build Instance;
    public Transform player;
    public Transform preBuildParent;
    public Constructible selectedBuild;
    public GameObject preBuild = null;

    private void Awake()
    {
        Instance = this;
        selectedBuild = player.GetComponent<Player>().buildSelected;
    }

    public void SelectBuild(Constructible constructible)
    {
        selectedBuild = constructible;
    }

    void Update()
    {
        if (selectedBuild != null)
        {
            if (preBuild == null)
            {
                preBuild = Instantiate(selectedBuild.Object, player.transform.position, player.transform.rotation, preBuildParent);
                print(selectedBuild);
            }
            else if (selectedBuild != null && preBuild != null)
            {
                preBuild.transform.position = player.Find("PlayerObj").transform.position;
                preBuild.transform.rotation = player.Find("PlayerObj").transform.rotation;
            }
        }
    }
}
