using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInv : MonoBehaviour
{
    public GameObject inventory;
    public KeyCode toggleKey;
    public Transform player;

    void Update()
    {
        if (player.GetComponent<Player>().playing == false)
        {
            return;
        }

        toggleKey = Keybinds.Instance.OpenInventory;
        if (Input.GetKeyDown(toggleKey))
        {
            if (inventory.activeSelf)
            {
                //Close inventory
                inventory.SetActive(false);

                CameraController.Instance.LockMouse();
            }
            else
            {
                //Open inventory
                inventory.SetActive(true);
                InventoryManager.Instance.ListItems();

                CameraController.Instance.UnlockMouse();
            }
        }
    }
}