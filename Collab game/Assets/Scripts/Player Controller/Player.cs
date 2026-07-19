using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public GameObject player;
    public bool playing = false;

    public GameObject mainMenu;

    void Start()
    {
        mainMenu.SetActive(true);
    }
}
