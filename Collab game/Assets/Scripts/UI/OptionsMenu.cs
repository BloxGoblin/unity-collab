using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance;

    public GameObject optionsUi;
    public Transform container;
    private GameObject menuReturn;

    private bool editMode = false;
    private string editingKeybind;

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
        if (editMode == false)
        {
            optionsUi.SetActive(false);
            menuReturn.SetActive(true);
            menuReturn = null;
        }
    }

    public void EditKeyBind(string keybind)
    {
        if (editMode == false)
        {
            editMode = true;
            editingKeybind = keybind;
        }
    }

    void Update()
    {
        if (editMode == true && editingKeybind != null)
        {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    editMode = false;
                    if (code != KeyCode.Escape)
                    {
                        SaveKeybind(editingKeybind, code);
                        editingKeybind = null;
                    }
                }
            }
        }
    }

    private void SaveKeybind(string prefName, KeyCode key)
    {
        PlayerPrefs.SetString(prefName, key.ToString()); //Set string equal to a string that spells out the keybind for guy
        PlayerPrefs.Save();
        print("Saved " + key.ToString() + " as keybind for " + prefName);

        Keybinds.Instance.UpdateKeybinds();
    }
}
