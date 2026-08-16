using UnityEngine;

public class OpenBuildMenu : MonoBehaviour
{
    public GameObject buildMenu;
    public KeyCode toggleKey;
    public Transform player;

    void Update()
    {
        if (player.GetComponent<Player>().playing == false)
        {
            return;
        }
        
        toggleKey = Keybinds.Instance.ToolPrimaryAction;
        if (Input.GetKeyDown(toggleKey))
        {
            if (buildMenu.activeSelf)
            {
                buildMenu.SetActive(false);

                CameraController.Instance.LockMouse();
            }
            else
            {
                buildMenu.SetActive(true);
                BuildMenuHandler.Instance.ListButtons();

                CameraController.Instance.UnlockMouse();
            }
        }
    }
}