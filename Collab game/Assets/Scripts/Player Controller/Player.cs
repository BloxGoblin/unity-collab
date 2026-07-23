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

    void Start()
    {
        mainMenu.SetActive(true);
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayerData(this);
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

    void Update()
    {
        //Pause
        if (Input.GetKeyDown(KeyCode.Escape) && player.GetComponent<Player>().playing == true)
        {
            pauseMenu.SetActive(true);
            CameraController.Instance.UnlockMouse();
            player.GetComponent<Player>().playing = false;
        }
    }
}
