using UnityEngine;
using UnityEngine.UI;

public class MenuPlay : MonoBehaviour
{
    public GameObject menu;
    public Transform player;

    public void play()
    {
        menu.SetActive(false);
        player.GetComponent<Player>().playing = true;
        CameraController.Instance.LockMouse();
    }
}