using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class InvButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;

    private bool inButton = false;

    [Header("Keybinds")]
    public KeyCode dropKey = KeyCode.Mouse1; //Right click is default drop button

    public void OnPointerEnter(PointerEventData eventData)
    {
        inButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inButton = false;
    }

    void Update()
    {
        if (inButton == true)
        {
            if (Input.GetKeyDown(dropKey))
            {
                GameObject obj = item.Object;
                //Instantiate(obj, )
            }
        }
    }
}
