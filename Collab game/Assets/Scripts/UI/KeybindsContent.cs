using TMPro;
using UnityEngine;

public class KeybindsContent : MonoBehaviour
{
    public static KeybindsContent Instance;

    public Transform content;

    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        foreach (Transform keyButton in content)
        {
            if (keyButton.Find("Key"))
            {
                foreach (var key in Keybinds.Instance.bindings)
                {
                    if (key.actionName == keyButton.name)
                    {
                        string keybind = key.key.ToString();
                        keyButton.Find("Key").Find("Key").GetComponent<TMP_Text>().text = "(" + keybind + ")";
                    }
                }
            }
        }
    }
}
