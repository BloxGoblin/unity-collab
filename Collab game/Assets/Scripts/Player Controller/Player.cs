using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public GameObject player;
    public bool playing = false;

    public GameObject mainMenu;
    public GameObject pauseMenu;

    void Start()
    {
        mainMenu.SetActive(true);
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
