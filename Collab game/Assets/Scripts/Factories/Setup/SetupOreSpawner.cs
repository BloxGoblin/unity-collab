using UnityEngine;

public class SetupOreSpawner : MonoBehaviour
{
    public static SetupOreSpawner Instance;
    public Transform _oresParent;
    public Transform player;

    private void Awake()
    {
        Instance = this;
    }

    public void SetupSpawner(GameObject spawner)
    {
        if (spawner.GetComponent<SpawnOre>())
        {
            spawner.GetComponent<SpawnOre>()._oresParent = _oresParent;
            spawner.GetComponent<SpawnOre>().player = player;
        }
    }
}
