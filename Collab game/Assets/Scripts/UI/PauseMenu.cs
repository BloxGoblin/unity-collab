using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Transform player;
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<Player>().playing = true;
        CameraController.Instance.LockMouse();
    }
}
