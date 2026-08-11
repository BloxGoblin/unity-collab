using System.Collections.Generic;
using UnityEngine;

// This is a horrible way to do this and I am aware of that but I dont feel like making it better because this is funnier

public class Keybinding
{
    public string actionName;
    public KeyCode key;
}

public class Keybinds : MonoBehaviour
{
    public static Keybinds Instance;
    public List<Keybinding> bindings = new List<Keybinding>(); // Purely for accessing action name and keybind in other scripts

    [Header("Gameplay")]
    public KeyCode Interact = KeyCode.E;
    public KeyCode StoreItem = KeyCode.Mouse0;
    public KeyCode OpenInventory = KeyCode.Tab;

    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        bindings.Add(new Keybinding {actionName = "Interact", key = Interact});
        bindings.Add(new Keybinding {actionName = "StoreItem", key = StoreItem});
        bindings.Add(new Keybinding {actionName = "OpenInventory", key = OpenInventory});

        UpdateKeybinds();
    }

    public void UpdateKeybinds()
    {
        if (LoadKey("Interact", Interact) != Interact) // Interact without quotations is equal to the default key value because my code fucking sucks
        {
            Interact = LoadKey("Interact", Interact);
        }

        if (LoadKey("OpenInventory", OpenInventory) != OpenInventory)
        {
            OpenInventory = LoadKey("OpenInventory", OpenInventory);
        }

        if (LoadKey("StoreItem", StoreItem) != StoreItem)
        {
            StoreItem = LoadKey("StoreItem", StoreItem);
        }

        for (int i = 0; i < bindings.Count; i++)
        {
            if (LoadKey(bindings[i].actionName, bindings[i].key) != bindings[i].key)
            {
                bindings[i].key = LoadKey(bindings[i].actionName, bindings[i].key); // Confusing ass code but essentially does same thing as above in a loop to update the list
            }
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
