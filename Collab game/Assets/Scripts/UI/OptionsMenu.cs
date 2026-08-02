using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance;

    public GameObject optionsUi;
    public Transform container;
    private GameObject menuReturn;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenOptionsUI(GameObject currentMenu)
    {
        menuReturn = currentMenu;
        optionsUi.SetActive(true);
        currentMenu.SetActive(false);
    }

    public void CloseOptionsUI()
    {
        optionsUi.SetActive(false);
        menuReturn.SetActive(true);
        menuReturn = null;
    }
}
