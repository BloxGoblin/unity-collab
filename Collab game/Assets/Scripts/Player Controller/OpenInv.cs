using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInv : MonoBehaviour
{
    public GameObject inventory;
    public KeyCode toggleKey = KeyCode.Tab;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
            }
            else
            {
                inventory.SetActive(true);
                InventoryManager.Instance.ListItems();
            }
        }
    }
}