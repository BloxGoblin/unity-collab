using UnityEngine;

public class Keybinds : MonoBehaviour
{
    public static Keybinds Instance;

    [Header("Gameplay")]
    public KeyCode Interact = KeyCode.E;
    public KeyCode OpenInventory = KeyCode.Tab;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        UpdateKeybinds();
    }

    public void UpdateKeybinds()
    {
        if (LoadKey("Interact", Interact) != Interact) // Interact without quotations is equal to the default key value because my code fucking sucks
        {
            Interact = LoadKey("Interact", Interact);
        }
    }

    private KeyCode LoadKey(string prefName, KeyCode defaultKey)
    {
        string keyString = PlayerPrefs.GetString(prefName, defaultKey.ToString());

        // Make sure the string guy has stored can be used as a keycode
        if (System.Enum.TryParse(keyString, out KeyCode parsedKey))
        {
            return parsedKey;
        }
        else
        {
            Debug.LogWarning("BIG OOPSIE!!!!!: Invalid key");
            return defaultKey;
        }
    }
}
