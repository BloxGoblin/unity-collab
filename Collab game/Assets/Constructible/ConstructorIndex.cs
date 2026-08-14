using System.Collections.Generic;
using UnityEngine;

public class ConstructorIndex : MonoBehaviour
{
    public static ConstructorIndex Instance;
    public List<Constructible> Constructibles = new List<Constructible>();

    private void Awake()
    {
        Instance = this;
    }
}
