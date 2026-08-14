using UnityEngine;

[CreateAssetMenu(fileName = "Constructible", menuName = "Constructible/Create New Constructible")]
public class Constructible : ScriptableObject
{
    public int id;
    public string objectName;
    public string objectDesc;
    public GameObject Object;
    public Sprite icon;
    
}
