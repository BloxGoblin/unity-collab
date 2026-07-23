using System.Collections.Generic;
using UnityEngine;

public class ItemsIndex : MonoBehaviour
{
    public static ItemsIndex Instance;
    public List<Item> ItemIndex = new List<Item>();

    private void Awake()
    {
        Instance = this;
    }
}
