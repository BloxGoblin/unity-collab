using UnityEngine;
using UnityEngine.UI;

public class BuildMenuHandler : MonoBehaviour
{
    public static BuildMenuHandler Instance;

    public Transform player;
    public Transform UiContent;
    public GameObject buttonTemplate;

    private void Awake()
    {
        Instance = this;
    }

    public void ListButtons()
    {
        foreach (Transform button in UiContent) // Clean up buttons already there
        {
            Destroy(button.gameObject);
        }
        foreach (var constructible in ConstructorIndex.Instance.Constructibles)
        {
            print(constructible.name);
            GameObject button = Instantiate(buttonTemplate, UiContent);
            var buttonIcon = button.transform.Find("Icon").GetComponent<Image>();
            buttonIcon.sprite = constructible.icon;
        }
    }
}
