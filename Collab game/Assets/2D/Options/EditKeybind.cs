using UnityEngine;

public class EditKeybind : MonoBehaviour
{
    public string Keybind; // Gets put in as name of the player preference (MUST be exact same name as the keybind is called in player keybind script)
    public void EnableEditMode()
    {
        if (Keybind != null)
        {
            OptionsMenu.Instance.EditKeyBind(Keybind);
        }
    }
}
