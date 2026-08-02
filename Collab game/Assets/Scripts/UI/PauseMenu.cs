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

    public void achievements()
    {
        AchievementsUI.Instance.OpenAchievementsUI(pauseMenu);
        pauseMenu.SetActive(false);
    }

    public void Options()
    {
        OptionsMenu.Instance.OpenOptionsUI(pauseMenu);
    }

    public void SaveGame()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<Player>().playing = true;
        CameraController.Instance.LockMouse();
        
        player.GetComponent<Player>().SaveGame();
    }
}
